using System;
using QLDH.Entities.Interface;


namespace QLDH.Entities
{
    [Serializable]
    public class Faculty : ISearchable
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
        
        public bool Matches(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return true;
            string k = keyword.ToLower();
            return FacultyId?.ToLower().Contains(k) == true ||
                   FacultyName?.ToLower().Contains(k) == true ||
                   DeanName?.ToLower().Contains(k) == true;
        }
    }
}