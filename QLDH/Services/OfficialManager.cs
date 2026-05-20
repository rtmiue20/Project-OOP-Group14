using System;
using System.Collections.Generic;
using MySqlConnector;
using QLDH.Entities;

namespace QLDH.Service
{
    public class OfficialManager : BaseManager<Official>
    {
        private string connectionString = "Server=localhost;Port=3306;Database=QLDH_DB;User ID=root;Password=your_password;Charset=utf8mb4;";

        protected override string GetId(Official item) => item.StudentId;

        public override List<Official> GetAll()
        {
            items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, FullName, BirthYear, HouseNumber, Street, District, ClassName, Role, Term, TrainingScore FROM NhanSu WHERE LoaiNhanSu = 'Cán bộ Đoàn'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Address addr = new Address(r["HouseNumber"].ToString(), r["Street"].ToString(), r["District"].ToString());
                        items.Add(new Official
                        {
                            StudentId = r["Id"].ToString(),
                            FullName = r["FullName"].ToString(),
                            BirthYear = Convert.ToInt32(r["BirthYear"]),
                            ResidentAddress = addr,
                            ClassName = r["ClassName"].ToString(),
                            Role = r["Role"].ToString(),
                            Term = r["Term"].ToString(),
                            TrainingScore = Convert.ToDouble(r["TrainingScore"])
                        });
                    }
                }
            }
            return items;
        }

        public override void Add(Official item)
        {
            base.Add(item);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO NhanSu (Id, LoaiNhanSu, FullName, BirthYear, HouseNumber, Street, District, ClassName, Role, Term, TrainingScore) 
                                 VALUES (@Id, 'Cán bộ Đoàn', @FullName, @BirthYear, @HouseNumber, @Street, @District, @ClassName, @Role, @Term, @TrainingScore)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", item.StudentId);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
                    cmd.Parameters.AddWithValue("@HouseNumber", item.ResidentAddress.HouseNumber);
                    cmd.Parameters.AddWithValue("@Street", item.ResidentAddress.Street);
                    cmd.Parameters.AddWithValue("@District", item.ResidentAddress.District);
                    cmd.Parameters.AddWithValue("@ClassName", item.ClassName);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    cmd.Parameters.AddWithValue("@Term", item.Term);
                    cmd.Parameters.AddWithValue("@TrainingScore", item.TrainingScore);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Update(Official item)
        {
            base.Update(item);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE NhanSu SET FullName=@FullName, BirthYear=@BirthYear, HouseNumber=@HouseNumber, 
                                 Street=@Street, District=@District, ClassName=@ClassName, Role=@Role, Term=@Term WHERE Id=@Id AND LoaiNhanSu='Cán bộ Đoàn'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", item.StudentId);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@BirthYear", item.BirthYear);
                    cmd.Parameters.AddWithValue("@HouseNumber", item.ResidentAddress.HouseNumber);
                    cmd.Parameters.AddWithValue("@Street", item.ResidentAddress.Street);
                    cmd.Parameters.AddWithValue("@District", item.ResidentAddress.District);
                    cmd.Parameters.AddWithValue("@ClassName", item.ClassName);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    cmd.Parameters.AddWithValue("@Term", item.Term);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Delete(string id)
        {
            base.Delete(id);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM NhanSu WHERE Id=@Id AND LoaiNhanSu='Cán bộ Đoàn'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override List<Official> Search(string keyword)
        {
            List<Official> result = new List<Official>();
            foreach (var off in GetAll())
            {
                if (off.StudentId.Contains(keyword) || off.FullName.Contains(keyword))
                    result.Add(off);
            }
            return result;
        }
    }
}
