using System;
using QLDH.Entities.Interface;

namespace QLDH.Entities
{
    [Serializable]
    public class Lecturer : Human, ISearchable
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
        
        public bool Matches(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return true;
            string k = keyword.ToLower();
            return LecturerId?.ToLower().Contains(k) == true ||
                   FullName?.ToLower().Contains(k) == true ||
                   Department?.ToLower().Contains(k) == true;
        }
    }
}