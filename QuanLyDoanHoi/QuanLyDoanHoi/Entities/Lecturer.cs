using System;

namespace QuanLyDoanHoi.Entities
{
    [Serializable]
    public class Lecturer : Human //tính chất kế thừa 
    {
        private string lecturerId;
        private string department;

        public string LecturerId { get { return lecturerId; } set { lecturerId = value; } } 
        public string Department { get { return department; } set { department = value; } } 

        public Lecturer() { }

        public override void DisplayInfo()
        {
            Console.WriteLine("Lecturer: " + this.FullName + " - Faculty: " + this.department);
        }
    }
}