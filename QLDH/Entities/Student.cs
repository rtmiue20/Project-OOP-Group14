using System;
using QLDH.Entities.Interface;


namespace QLDH.Entities
{
    [Serializable]
    public class Student : Human, IComparable<Student>, ISearchable
    {
        private string studentId;
        private string className;
        private double trainingScore;

        public string StudentId { get { return studentId; } set { studentId = value; } }
        public string ClassName { get { return className; } set { className = value; } }
        public double TrainingScore { get { return trainingScore; } set { trainingScore = value; } } // DiemRenLuyen

        public Student() { }

        // Ghi đè phương thức
        public override void DisplayInfo()
        {
            Console.WriteLine("Student: " + this.FullName + " - ID: " + this.studentId);
        }

        // Hàm tính điểm ảo để lớp con (CanBoDoan) có thể ghi đè
        public virtual void CalculateScore(UnionEvent unionEvent)
        {
            this.trainingScore += unionEvent.BonusScore ; // Quan hệ Dependence 
        }
        
        // Khai thác các Interface
        public int CompareTo(Student? other)
        {
            if (other == null) return 1;
            return other.TrainingScore.CompareTo(this.TrainingScore); // Sắp xếp theo điểm giảm dần
        }

        public bool Matches(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return true;
            string k = keyword.ToLower();
            return StudentId?.ToLower().Contains(k) == true ||
                   FullName?.ToLower().Contains(k) == true ||
                   ClassName?.ToLower().Contains(k) == true;
        }
        
        // Operators Overloading
        public static Student operator +(Student s, int bonus)
        {
            s.TrainingScore += bonus;
            return s;
        }

        public static bool operator ==(Student? a, Student? b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.StudentId == b.StudentId;
        }

        public static bool operator !=(Student? a, Student? b) => !(a == b);
    }
}