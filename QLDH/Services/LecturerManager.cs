using System;
using System.Collections.Generic;
using MySqlConnector;
using QLDH.Entities;

namespace QLDH.Service
{
    public class LecturerManager : BaseManager<Lecturer>
    {
        private string connectionString = "Server=localhost;Port=3306;Database=QLDH;User ID=root;Password=049206;Charset=utf8mb4;";

        // 1. C - Create
        public override void Add(Lecturer item)
        {
            base.Add(item);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO NhanSu (Id, LoaiNhanSu, FullName, BirthYear, HouseNumber, Street, District, Department) 
                                 VALUES (@Id, 'Giảng viên', @FullName, @BirthYear, @HouseNumber, @Street, @District, @Department)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", item.LecturerId);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
                    cmd.Parameters.AddWithValue("@HouseNumber", item.ResidentAddress.HouseNumber);
                    cmd.Parameters.AddWithValue("@Street", item.ResidentAddress.Street);
                    cmd.Parameters.AddWithValue("@District", item.ResidentAddress.District);
                    cmd.Parameters.AddWithValue("@Department", item.Department);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        // 2. R - Read
        protected override string GetId(Lecturer item) => item.LecturerId;

        public override List<Lecturer> GetAll()
        {
            items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, FullName, BirthYear, HouseNumber, Street, District, Department FROM NhanSu WHERE LoaiNhanSu = 'Giảng viên'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Address addr = new Address(r["HouseNumber"].ToString(), r["Street"].ToString(), r["District"].ToString());
                        items.Add(new Lecturer
                        {
                            LecturerId = r["Id"].ToString(),
                            FullName = r["FullName"].ToString(),
                            BirthYear = Convert.ToInt32(r["BirthYear"]),
                            ResidentAddress = addr,
                            Department = r["Department"].ToString()
                        });
                    }
                }
            }
            return items;
        }
        

        // 3. U - Update
        public override void Update(Lecturer item)
        {
            base.Update(item);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE NhanSu SET FullName=@FullName, BirthYear=@BirthYear, HouseNumber=@HouseNumber, 
                                 Street=@Street, District=@District, Department=@Department WHERE Id=@Id AND LoaiNhanSu='Giảng viên'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", item.LecturerId);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
                    cmd.Parameters.AddWithValue("@HouseNumber", item.ResidentAddress.HouseNumber);
                    cmd.Parameters.AddWithValue("@Street", item.ResidentAddress.Street);
                    cmd.Parameters.AddWithValue("@District", item.ResidentAddress.District);
                    cmd.Parameters.AddWithValue("@Department", item.Department);
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
                string query = "DELETE FROM NhanSu WHERE Id=@Id AND LoaiNhanSu='Giảng viên'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Search function
        public override List<Lecturer> Search(string keyword)
        {
            List<Lecturer> result = new List<Lecturer>();
            foreach (var lec in GetAll())
            {
                if (lec.LecturerId.Contains(keyword) || lec.FullName.Contains(keyword))
                    result.Add(lec);
            }
            return result;
        }
    }
}