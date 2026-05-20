using System;
using System.Collections.Generic;
using MySqlConnector;
using QLDH.Entities;

namespace QLDH.Service
{
    public class EventManager : BaseManager<UnionEvent>
    {
        private string connectionString = "Server=localhost;Port=3306;Database=QLDH_DB;User ID=root;Password=your_password;Charset=utf8mb4;";

        // 1. C - Create
        public override void Add(UnionEvent item)
        {
            base.Add(item);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO SuKien (EventId, EventName, BonusScore) 
                                 VALUES (@EventId, @EventName, @BonusScore)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventId", item.EventId);
                    cmd.Parameters.AddWithValue("@EventName", item.EventName);
                    cmd.Parameters.AddWithValue("@BonusScore", item.BonusScore);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // 2. R - Read
        protected override string GetId(UnionEvent item) => item.EventId;

        public override List<UnionEvent> GetAll()
        {
            items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT EventId, EventName, BonusScore FROM SuKien";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        items.Add(new UnionEvent
                        {
                            EventId = r["EventId"].ToString(),
                            EventName = r["EventName"].ToString(),
                            BonusScore = Convert.ToDouble(r["BonusScore"])
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
                string query = @"UPDATE SuKien SET EventName=@EventName, BonusScore=@BonusScore 
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
                string query = "DELETE FROM SuKien WHERE EventId=@EventId";
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
            // Đã thay thế 'var' thành kiểu dữ liệu tường minh 'UnionEvent' theo yêu cầu số 5
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
                string query = "SELECT StudentId, EventId, CheckInTime, Status FROM LichSuThamGia WHERE EventId = @EventId";
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

        // Đăng ký tham gia sự kiện và cộng điểm rèn luyện dựa trên mối quan hệ Đa hình (Polymorphism)
        public void AddParticipation(ParticipationHistory history, double bonusScore)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // 1. Thêm vào bảng LichSuThamGia
                string insertQuery = @"INSERT INTO LichSuThamGia (StudentId, EventId, CheckInTime, Status) 
                                       VALUES (@StudentId, @EventId, @CheckInTime, @Status)";
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", history.StudentIdReference);
                    cmd.Parameters.AddWithValue("@EventId", history.EventIdReference);
                    cmd.Parameters.AddWithValue("@CheckInTime", history.CheckInTime);
                    cmd.Parameters.AddWithValue("@Status", history.Status);
                    cmd.ExecuteNonQuery();
                }

                // 2. Xác định vai trò đối tượng để cộng điểm (Đa hình)
                string typeQuery = "SELECT LoaiNhanSu, TrainingScore FROM NhanSu WHERE Id = @Id";
                string loaiNhanSu = "";
                double curScore = 0;

                using (MySqlCommand cmd = new MySqlCommand(typeQuery, conn))
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

                // Triển khai logic hướng đối tượng thông qua thực thể thực tế
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
                    off.CalculateScore(dummyEvent); // Được nhân hệ số 1.2 nhờ cơ chế ghi đè (Override)
                    newScore = off.TrainingScore;
                }

                // 3. Cập nhật điểm rèn luyện mới vào cơ sở dữ liệu
                string updateScoreQuery = "UPDATE NhanSu SET TrainingScore = @NewScore WHERE Id = @Id";
                using (MySqlCommand cmd = new MySqlCommand(updateScoreQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@NewScore", newScore);
                    cmd.Parameters.AddWithValue("@Id", history.StudentIdReference);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Hủy đăng ký tham gia sự kiện (Trừ lại điểm rèn luyện tương ứng)
        public void DeleteParticipation(string studentId, string eventId, double bonusScore)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // 1. Xóa bản ghi lịch sử tham gia
                string deleteQuery = "DELETE FROM LichSuThamGia WHERE StudentId=@StudentId AND EventId=@EventId";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    cmd.ExecuteNonQuery();
                }

                // 2. Kiểm tra lại thông tin đối tượng
                string typeQuery = "SELECT LoaiNhanSu, TrainingScore FROM NhanSu WHERE Id = @Id";
                string loaiNhanSu = "";
                double curScore = 0;

                using (MySqlCommand cmd = new MySqlCommand(typeQuery, conn))
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
                // Hoàn tác điểm dựa trên cách tính của từng nhóm thực thể
                double standardDeduction = bonusScore;
                if (loaiNhanSu == "Cán bộ Đoàn")
                {
                    standardDeduction = bonusScore * 1.2;
                }
                double newScore = Math.Max(0, curScore - standardDeduction);
                // 3. Cập nhật lại điểm sau khi hoàn tác
                string updateScoreQuery = "UPDATE NhanSu SET TrainingScore = @NewScore WHERE Id = @Id";
                using (MySqlCommand cmd = new MySqlCommand(updateScoreQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@NewScore", newScore);
                    cmd.Parameters.AddWithValue("@Id", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}