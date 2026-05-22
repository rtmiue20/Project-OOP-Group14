using System;
using System.Collections.Generic;
using MySqlConnector;
using QLDH.Entities;

namespace QLDH.Service
{
    public class OfficialManager : BaseManager<Official>
    {
        private string connectionString = "Server=localhost;Port=3306;Database=QLDH;User ID=root;Password=049206;Charset=utf8mb4;";

        // 1. C - Create
        public override void Add(Official item)
        {
            base.Add(item);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    // Thêm vào bảng students
                    string query = @"INSERT INTO students (StudentId, FullName, BirthYear, ClassName, TrainingScore) 
                                     VALUES (@Id, @FullName, @BirthYear, @ClassName, @TrainingScore)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", item.StudentId);
                        cmd.Parameters.AddWithValue("@FullName", item.FullName);
                        cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
                        cmd.Parameters.AddWithValue("@ClassName", item.ClassName);
                        cmd.Parameters.AddWithValue("@TrainingScore", item.TrainingScore);
                        cmd.ExecuteNonQuery();
                    }

                    // Thêm vào bảng officials
                    string offQuery = @"INSERT INTO officials (StudentId, Role, Term) 
                                        VALUES (@Id, @Role, @Term)";
                    using (MySqlCommand cmd = new MySqlCommand(offQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", item.StudentId);
                        cmd.Parameters.AddWithValue("@Role", item.Role);
                        cmd.Parameters.AddWithValue("@Term", item.Term);
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
        protected override string GetId(Official item)
        {
            return item.StudentId;
        }

        public override List<Official> GetAll()
        {
            items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT s.StudentId, s.FullName, s.BirthYear, s.ClassName, s.TrainingScore,
                                        o.Role, o.Term,
                                        a.HouseNumber, a.Street, a.District
                                 FROM students s
                                 JOIN officials o ON s.StudentId = o.StudentId
                                 LEFT JOIN addresses a ON s.StudentId = a.StudentId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Address addr = new Address(
                            r["HouseNumber"]?.ToString() ?? "",
                            r["Street"]?.ToString() ?? "",
                            r["District"]?.ToString() ?? "");

                        Official officialItem = new Official();
                        officialItem.StudentId = r["StudentId"].ToString();
                        officialItem.FullName = r["FullName"].ToString();
                        officialItem.BirthYear = Convert.ToInt32(r["BirthYear"]);
                        officialItem.ClassName = r["ClassName"].ToString();
                        officialItem.TrainingScore = Convert.ToDouble(r["TrainingScore"]);
                        officialItem.Role = r["Role"]?.ToString() ?? "";
                        officialItem.Term = r["Term"]?.ToString() ?? "";
                        officialItem.ResidentAddress = addr;

                        items.Add(officialItem);
                    }
                }
            }
            return items;
        }

        // 3. U - Update
        public override void Update(Official item)
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

                    string offQuery = @"UPDATE officials SET Role=@Role, Term=@Term WHERE StudentId=@Id";
                    using (MySqlCommand cmd = new MySqlCommand(offQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", item.StudentId);
                        cmd.Parameters.AddWithValue("@Role", item.Role);
                        cmd.Parameters.AddWithValue("@Term", item.Term);
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
                    // Xóa officials trước (foreign key)
                    string offQuery = "DELETE FROM officials WHERE StudentId=@Id";
                    using (MySqlCommand cmd = new MySqlCommand(offQuery, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }

                    // Xóa địa chỉ
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
        public override List<Official> Search(string keyword)
        {
            List<Official> result = new List<Official>();
            List<Official> allOfficials = GetAll();

            foreach (Official off in allOfficials)
            {
                if (off.StudentId.Contains(keyword) || off.FullName.Contains(keyword) || off.ClassName.Contains(keyword))
                {
                    result.Add(off);
                }
            }
            return result;
        }
    }
}