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


        public override void CalculateScore(double eventScore)
        {

            this.TrainingScore += (eventScore * 1.2);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Official: " + this.FullName + " - Role: " + this.role);
        }
    }
}