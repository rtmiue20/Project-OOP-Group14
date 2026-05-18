using System;

namespace QuanLyDoanHoi.Entities
{
    [Serializable]
    public class Official : Student // Kế thừa
    {
        private string role;
        private string term;

        public string Role { get { return role; } set { role = value; } }  
        public string Term { get { return term; } set { term = value; } } 

        public Official() { }


        public override void CalculateScore(UnionEvent unionEvent)
        {
            // Cán bộ đoàn được nhân hệ số 1.2 điểm thưởng
            this.TrainingScore += (unionEvent.BonusScore * 1.2); // Quan hệ Dependence 
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Official: " + this.FullName + " - Role: " + this.role);
        }
    }
}