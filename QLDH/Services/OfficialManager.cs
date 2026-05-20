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
        
        // 2. R - Read
        // KHÔNG dùng dấu => ở đây nữa, chuyển về hàm có return rõ ràng
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
                string query = "SELECT Id, FullName, BirthYear, HouseNumber, Street, District, ClassName, Role, Term, TrainingScore FROM NhanSu WHERE LoaiNhanSu = 'Cán bộ Đoàn'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Address addr = new Address(r["HouseNumber"].ToString(), r["Street"].ToString(), r["District"].ToString());
                        
                        // Khai báo tường minh đối tượng cụ thể thay vì dùng khởi tạo nhanh kiểu Object Initializer
                        Official officialItem = new Official();
                        officialItem.StudentId = r["Id"].ToString();
                        officialItem.FullName = r["FullName"].ToString();
                        officialItem.BirthYear = Convert.ToInt32(r["BirthYear"]);
                        officialItem.ResidentAddress = addr;
                        officialItem.ClassName = r["ClassName"].ToString();
                        officialItem.Role = r["Role"].ToString();
                        officialItem.Term = r["Term"].ToString();
                        officialItem.TrainingScore = Convert.ToDouble(r["TrainingScore"]);
                        
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
        
        // 4. D - Delete
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

        // Search function
        public override List<Official> Search(string keyword)
        {
            List<Official> result = new List<Official>();
            List<Official> allOfficials = GetAll(); // Khai báo kiểu rõ ràng
            
            // Thay đổi "var" thành kiểu "Official" rõ ràng
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
