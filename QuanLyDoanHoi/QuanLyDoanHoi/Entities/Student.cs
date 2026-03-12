using System;

namespace QuanLyDoanHoi.Entities
{
    [Serializable]
    public class Student : Human // Kế thừa Nguoi [cite: 34, 57]
    {
        private string studentId;
        private string className;
        private double trainingScore;

        public string StudentId { get { return studentId; } set { studentId = value; } }
        public string ClassName { get { return className; } set { className = value; } }
        public double TrainingScore { get { return trainingScore; } set { trainingScore = value; } } // DiemRenLuyen [cite: 35]

        public Student() { }

        // Ghi đè phương thức [cite: 36]
        public override void DisplayInfo()
        {
            Console.WriteLine("Student: " + this.FullName + " - ID: " + this.studentId);
        }

        // Hàm tính điểm ảo để lớp con (CanBoDoan) có thể ghi đè
        public virtual void CalculateScore(double eventScore)
        {
            this.trainingScore += eventScore;
        }
    }
}