using System;
using System.Collections.Generic;
using MySqlConnector;
using QLDH.Entities;

namespace QLDH.Service
{
    public class EventManager : BaseManager<UnionEvent>
    {
        private string connectionString = "Server=localhost;Port=3306;Database=QLDH;User ID=root;Password=049206;Charset=utf8mb4;";

        // 1. C - Create
        public override void Add(UnionEvent item)
        {
            base.Add(item);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO unionevents (EventId, EventName, BonusScore, Address) 
                                 VALUES (@EventId, @EventName, @BonusScore, @Address)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventId", item.EventId);
                    cmd.Parameters.AddWithValue("@EventName", item.EventName);
                    cmd.Parameters.AddWithValue("@BonusScore", item.BonusScore);
                    //cmd.Parameters.AddWithValue("@Address", item.Address);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 2. R - Read
        protected override string GetId(UnionEvent item)
        {
            return item.EventId;
        }

        public override List<UnionEvent> GetAll()
        {
            items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT EventId, EventName, BonusScore, Address FROM unionevents";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        items.Add(new UnionEvent
                        {
                            EventId = r["EventId"].ToString(),
                            EventName = r["EventName"].ToString(),
                            BonusScore = Convert.ToDouble(r["BonusScore"]),
                            //Address = r["Address"]?.ToString() ?? ""
                        });
                    }
                }
            }
            return items;
        }

        // 3. U - Update
        public override void Update(UnionEvent item)
        {
            base.Update(item);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE unionevents SET EventName=@EventName, BonusScore=@BonusScore, Address=@Address 
                                 WHERE EventId=@EventId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventId", item.EventId);
                    cmd.Parameters.AddWithValue("@EventName", item.EventName);
                    cmd.Parameters.AddWithValue("@BonusScore", item.BonusScore);
                   
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM unionevents WHERE EventId=@EventId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Search function
        public override List<UnionEvent> Search(string keyword)
        {
            List<UnionEvent> result = new List<UnionEvent>();
            foreach (UnionEvent ev in GetAll())
            {
                if (ev.EventId.Contains(keyword) || ev.EventName.Contains(keyword))
                    result.Add(ev);
            }
            return result;
        }

        // =========================================================================
        // LOGIC PHỨC TẠP: CRUD CHO LỊCH SỬ THAM GIA & ĐỒNG BỘ TÍNH ĐIỂM RÈN LUYỆN
        // =========================================================================

        // Đọc lịch sử tham gia của một sự kiện cụ thể
        public List<ParticipationHistory> GetParticipantsByEvent(string eventId)
        {
            List<ParticipationHistory> list = new List<ParticipationHistory>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT StudentId, EventId, CheckInTime, Status FROM participationhistory WHERE EventId = @EventId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new ParticipationHistory
                            {
                                StudentIdReference = r["StudentId"].ToString(),
                                EventIdReference = r["EventId"].ToString(),
                                CheckInTime = Convert.ToDateTime(r["CheckInTime"]),
                                Status = r["Status"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        // Đăng ký tham gia sự kiện và cộng điểm rèn luyện (Đa hình - Polymorphism)
        public void AddParticipation(ParticipationHistory history, double bonusScore)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    // 1. Thêm vào bảng participationhistory
                    string insertQuery = @"INSERT INTO participationhistory (StudentId, EventId, CheckInTime, Status) 
                                           VALUES (@StudentId, @EventId, @CheckInTime, @Status)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", history.StudentIdReference);
                        cmd.Parameters.AddWithValue("@EventId", history.EventIdReference);
                        cmd.Parameters.AddWithValue("@CheckInTime", history.CheckInTime);
                        cmd.Parameters.AddWithValue("@Status", history.Status);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Lấy điểm hiện tại và kiểm tra có phải Cán bộ Đoàn không
                    string typeQuery = @"SELECT s.TrainingScore, 
                                                CASE WHEN o.StudentId IS NOT NULL THEN 'Cán bộ Đoàn' ELSE 'Sinh viên' END AS LoaiNhanSu
                                         FROM students s
                                         LEFT JOIN officials o ON s.StudentId = o.StudentId
                                         WHERE s.StudentId = @Id";
                    string loaiNhanSu = "";
                    double curScore = 0;

                    using (MySqlCommand cmd = new MySqlCommand(typeQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", history.StudentIdReference);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                loaiNhanSu = r["LoaiNhanSu"].ToString();
                                curScore = Convert.ToDouble(r["TrainingScore"]);
                            }
                        }
                    }

                    // 3. Tính điểm mới theo Đa hình (Polymorphism)
                    UnionEvent dummyEvent = new UnionEvent { BonusScore = bonusScore };
                    double newScore = curScore;

                    if (loaiNhanSu == "Sinh viên")
                    {
                        Student st = new Student { TrainingScore = curScore };
                        st.CalculateScore(dummyEvent);
                        newScore = st.TrainingScore;
                    }
                    else if (loaiNhanSu == "Cán bộ Đoàn")
                    {
                        Official off = new Official { TrainingScore = curScore };
                        off.CalculateScore(dummyEvent); // Nhân hệ số 1.2 nhờ Override
                        newScore = off.TrainingScore;
                    }

                    // 4. Cập nhật điểm rèn luyện
                    string updateScoreQuery = "UPDATE students SET TrainingScore = @NewScore WHERE StudentId = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(updateScoreQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@NewScore", newScore);
                        cmd.Parameters.AddWithValue("@Id", history.StudentIdReference);
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                }
            }
        }

        // Hủy đăng ký tham gia sự kiện (Trừ lại điểm rèn luyện)
        public void DeleteParticipation(string studentId, string eventId, double bonusScore)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    // 1. Xóa bản ghi lịch sử tham gia
                    string deleteQuery = "DELETE FROM participationhistory WHERE StudentId=@StudentId AND EventId=@EventId";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", studentId);
                        cmd.Parameters.AddWithValue("@EventId", eventId);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Lấy thông tin điểm và loại nhân sự
                    string typeQuery = @"SELECT s.TrainingScore,
                                                CASE WHEN o.StudentId IS NOT NULL THEN 'Cán bộ Đoàn' ELSE 'Sinh viên' END AS LoaiNhanSu
                                         FROM students s
                                         LEFT JOIN officials o ON s.StudentId = o.StudentId
                                         WHERE s.StudentId = @Id";
                    string loaiNhanSu = "";
                    double curScore = 0;

                    using (MySqlCommand cmd = new MySqlCommand(typeQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", studentId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                loaiNhanSu = r["LoaiNhanSu"].ToString();
                                curScore = Convert.ToDouble(r["TrainingScore"]);
                            }
                        }
                    }

                    // 3. Hoàn tác điểm theo loại nhân sự
                    double standardDeduction = bonusScore;
                    if (loaiNhanSu == "Cán bộ Đoàn")
                    {
                        standardDeduction = bonusScore * 1.2;
                    }
                    double newScore = Math.Max(0, curScore - standardDeduction);

                    // 4. Cập nhật lại điểm
                    string updateScoreQuery = "UPDATE students SET TrainingScore = @NewScore WHERE StudentId = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(updateScoreQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@NewScore", newScore);
                        cmd.Parameters.AddWithValue("@Id", studentId);
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                }
            }
        }
    }
}