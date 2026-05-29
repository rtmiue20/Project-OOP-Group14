using System;
using QLDH.Entities.Interface;

namespace QLDH.Entities
{
    [Serializable]
    public class Official : Student, ISearchable 
    {
        private string role;
        private string term;

        public string Role { get { return role; } set { role = value; } }  
        public string Term { get { return term; } set { term = value; } } 

        public Official() { }


        public override void CalculateScore(UnionEvent unionEvent)
        {
            // Quan hệ Dependence 

            this.TrainingScore += (unionEvent.BonusScore * 1.2);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Official: " + this.FullName + " - Role: " + this.role);
        }
        
        public bool Matches(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return true;
            string k = keyword.ToLower();
            return StudentId?.ToLower().Contains(k) == true ||
                   FullName?.ToLower().Contains(k) == true ||
                   Role?.ToLower().Contains(k) == true;
        }

        public int CompareTo(Official? other)   // Vì kế thừa Student nên có thể override
        {
            if (other == null) return 1;
            return other.TrainingScore.CompareTo(this.TrainingScore);
        }
    }
}