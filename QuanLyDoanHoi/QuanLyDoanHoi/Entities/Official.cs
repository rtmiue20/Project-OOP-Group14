using System;

namespace QuanLyDoanHoi.Entities
{
    [Serializable]
    public class Official : Student // Kế thừa SinhVien [cite: 37, 57]
    {
        private string role;
        private string term;

        public string Role { get { return role; } set { role = value; } } // ChucVu [cite: 38]
        public string Term { get { return term; } set { term = value; } } // NhiemKy [cite: 38]

        public Official() { }

        // Ghi đè tính điểm (nhân hệ số) - Tính đa hình [cite: 39]
        public override void CalculateScore(double eventScore)
        {
            // Cán bộ được nhân hệ số 1.2 điểm [cite: 22, 59]
            this.TrainingScore += (eventScore * 1.2);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Official: " + this.FullName + " - Role: " + this.role);
        }
    }
}