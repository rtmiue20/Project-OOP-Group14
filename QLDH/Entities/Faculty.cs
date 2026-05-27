using System;


namespace QLDH.Entities
{
    [Serializable]
    public class Faculty
    {
        public string FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string DeanName { get; set; } // Trưởng Khoa


        public Faculty()
        {
        }


        public Faculty(string facultyId, string facultyName, string deanName)
        {
            this.FacultyId = facultyId;
            this.FacultyName = facultyName;
            this.DeanName = deanName;
        }
    }
}