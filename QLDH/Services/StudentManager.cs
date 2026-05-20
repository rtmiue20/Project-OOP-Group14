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
                string query = @"INSERT INTO NhanSu (Id, LoaiNhanSu, FullName, BirthYear, HouseNumber, Street, District, ClassName, TrainingScore) 
                                 VALUES (@Id, 'Sinh viên', @FullName, @BirthYear, @HouseNumber, @Street, @District, @ClassName, @TrainingScore)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", item.StudentId);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
                    cmd.Parameters.AddWithValue("@HouseNumber", item.ResidentAddress.HouseNumber);
                    cmd.Parameters.AddWithValue("@Street", item.ResidentAddress.Street);
                    cmd.Parameters.AddWithValue("@District", item.ResidentAddress.District);
                    cmd.Parameters.AddWithValue("@ClassName", item.ClassName);
                    cmd.Parameters.AddWithValue("@TrainingScore", item.TrainingScore);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        // 2. R - Read
        protected override string GetId(Student item) => item.StudentId;

        public override List<Student> GetAll()
        {
            items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, FullName, BirthYear, HouseNumber, Street, District, ClassName, TrainingScore FROM NhanSu WHERE LoaiNhanSu = 'Sinh viên'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Address addr = new Address(r["HouseNumber"].ToString(), r["Street"].ToString(), r["District"].ToString());
                        items.Add(new Student
                        {
                            StudentId = r["Id"].ToString(),
                            FullName = r["FullName"].ToString(),
                            BirthYear = Convert.ToInt32(r["BirthYear"]),
                            ResidentAddress = addr,
                            ClassName = r["ClassName"].ToString(),
                            TrainingScore = Convert.ToDouble(r["TrainingScore"])
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
                string query = @"UPDATE NhanSu SET FullName=@FullName, BirthYear=@BirthYear, HouseNumber=@HouseNumber, 
                                 Street=@Street, District=@District, ClassName=@ClassName WHERE Id=@Id AND LoaiNhanSu='Sinh viên'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", item.StudentId);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
                    cmd.Parameters.AddWithValue("@HouseNumber", item.ResidentAddress.HouseNumber);
                    cmd.Parameters.AddWithValue("@Street", item.ResidentAddress.Street);
                    cmd.Parameters.AddWithValue("@District", item.ResidentAddress.District);
                    cmd.Parameters.AddWithValue("@ClassName", item.ClassName);
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
                string query = "DELETE FROM NhanSu WHERE Id=@Id AND LoaiNhanSu='Sinh viên'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Search function
        public override List<Student> Search(string keyword)
        {
            List<Student> result = new List<Student>();
            foreach (var st in GetAll())
            {
                if (st.StudentId.Contains(keyword) || st.FullName.Contains(keyword) || st.ClassName.Contains(keyword))
                    result.Add(st);
            }
            return result;
        }
    }
}