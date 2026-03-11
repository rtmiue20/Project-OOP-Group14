using System;

namespace QuanLyDoanHoi.Entities
{
    [Serializable]
    public class Lecturer : Human
    {
        private string lecturerId;
        private string department;

        public string LecturerId { get { return lecturerId; } set { lecturerId = value; } } // MaGiangVien [cite: 41]
        public string Department { get { return department; } set { department = value; } } // Khoa [cite: 41]

        public Lecturer() { }

        public override void DisplayInfo()
        {
            Console.WriteLine("Lecturer: " + this.FullName + " - Faculty: " + this.department);
        }
    }
}