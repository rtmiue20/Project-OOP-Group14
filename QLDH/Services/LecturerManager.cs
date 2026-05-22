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
                string query = @"INSERT INTO lecturers (LecturerId, FullName, BirthYear, Department) 
                                 VALUES (@Id, @FullName, @BirthYear, @Department)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", item.LecturerId);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
                    cmd.Parameters.AddWithValue("@Department", item.Department);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 2. R - Read
        protected override string GetId(Lecturer item)
        {
            return item.LecturerId;
        }

        public override List<Lecturer> GetAll()
        {
            items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT LecturerId, FullName, BirthYear, Department FROM lecturers";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        items.Add(new Lecturer
                        {
                            LecturerId = r["LecturerId"].ToString(),
                            FullName = r["FullName"].ToString(),
                            BirthYear = Convert.ToInt32(r["BirthYear"]),
                            Department = r["Department"].ToString(),
                            ResidentAddress = new Address("", "", "") // GV không có địa chỉ trong DB
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
                string query = @"UPDATE lecturers SET FullName=@FullName, BirthYear=@BirthYear, 
                                 Department=@Department WHERE LecturerId=@Id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", item.LecturerId);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
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
                string query = "DELETE FROM lecturers WHERE LecturerId=@Id";
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
            foreach (Lecturer lec in GetAll())
            {
                if (lec.LecturerId.Contains(keyword) || lec.FullName.Contains(keyword) || lec.Department.Contains(keyword))
                    result.Add(lec);
            }
            return result;
        }
    }
}