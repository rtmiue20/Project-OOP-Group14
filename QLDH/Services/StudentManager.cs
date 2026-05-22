using System;
using System.Collections.Generic;
using MySqlConnector;
using QLDH.Entities;

namespace QLDH.Service
{
    public class StudentManager : BaseManager<Student>
    {
        private string connectionString = "Server=localhost;Port=3306;Database=QLDH;User ID=root;Password=049206;Charset=utf8mb4;";

        // 1. C - Create
        public override void Add(Student item)
        {
            base.Add(item);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    // Thêm vào bảng students
                    string query = @"INSERT INTO students (StudentId, FullName, BirthYear, ClassName, TrainingScore, Role) 
                                     VALUES (@Id, @FullName, @BirthYear, @ClassName, @TrainingScore, 'Sinh viên thường')";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", item.StudentId);
                        cmd.Parameters.AddWithValue("@FullName", item.FullName);
                        cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
                        cmd.Parameters.AddWithValue("@ClassName", item.ClassName);
                        cmd.Parameters.AddWithValue("@TrainingScore", item.TrainingScore);
                        cmd.ExecuteNonQuery();
                    }

                    // Thêm địa chỉ vào bảng addresses
                    string addrQuery = @"INSERT INTO addresses (HouseNumber, Street, District, StudentId) 
                                         VALUES (@HouseNumber, @Street, @District, @Id)";
                    using (MySqlCommand cmd = new MySqlCommand(addrQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@HouseNumber", item.ResidentAddress?.HouseNumber ?? "");
                        cmd.Parameters.AddWithValue("@Street", item.ResidentAddress?.Street ?? "");
                        cmd.Parameters.AddWithValue("@District", item.ResidentAddress?.District ?? "");
                        cmd.Parameters.AddWithValue("@Id", item.StudentId);
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                }
            }
        }

        // 2. R - Read
        protected override string GetId(Student item)
        {
            return item.StudentId;
        }

        public override List<Student> GetAll()
        {
            items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT s.StudentId, s.FullName, s.BirthYear, s.ClassName, s.TrainingScore,
                                        a.HouseNumber, a.Street, a.District
                                 FROM students s
                                 LEFT JOIN addresses a ON s.StudentId = a.StudentId
                                 WHERE s.Role = 'Sinh viên thường' OR s.Role IS NULL";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Address addr = new Address(
                            r["HouseNumber"]?.ToString() ?? "",
                            r["Street"]?.ToString() ?? "",
                            r["District"]?.ToString() ?? "");
                        items.Add(new Student
                        {
                            StudentId = r["StudentId"].ToString(),
                            FullName = r["FullName"].ToString(),
                            BirthYear = Convert.ToInt32(r["BirthYear"]),
                            ClassName = r["ClassName"].ToString(),
                            TrainingScore = Convert.ToDouble(r["TrainingScore"]),
                            ResidentAddress = addr
                        });
                    }
                }
            }
            return items;
        }

        // 3. U - Update
        public override void Update(Student item)
        {
            base.Update(item);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    string query = @"UPDATE students SET FullName=@FullName, BirthYear=@BirthYear, 
                                     ClassName=@ClassName WHERE StudentId=@Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", item.StudentId);
                        cmd.Parameters.AddWithValue("@FullName", item.FullName);
                        cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
                        cmd.Parameters.AddWithValue("@ClassName", item.ClassName);
                        cmd.ExecuteNonQuery();
                    }

                    string addrQuery = @"UPDATE addresses SET HouseNumber=@HouseNumber, Street=@Street, 
                                         District=@District WHERE StudentId=@Id";
                    using (MySqlCommand cmd = new MySqlCommand(addrQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", item.StudentId);
                        cmd.Parameters.AddWithValue("@HouseNumber", item.ResidentAddress?.HouseNumber ?? "");
                        cmd.Parameters.AddWithValue("@Street", item.ResidentAddress?.Street ?? "");
                        cmd.Parameters.AddWithValue("@District", item.ResidentAddress?.District ?? "");
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
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
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    // Xóa địa chỉ trước
                    string addrQuery = "DELETE FROM addresses WHERE StudentId=@Id";
                    using (MySqlCommand cmd = new MySqlCommand(addrQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }

                    // Xóa sinh viên
                    string query = "DELETE FROM students WHERE StudentId=@Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                }
            }
        }

        // Search function
        public override List<Student> Search(string keyword)
        {
            List<Student> result = new List<Student>();
            foreach (Student st in GetAll())
            {
                if (st.StudentId.Contains(keyword) || st.FullName.Contains(keyword) || st.ClassName.Contains(keyword))
                    result.Add(st);
            }
            return result;
        }
    }
}