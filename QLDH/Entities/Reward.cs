using System;
using QLDH.Entities.Interface;


namespace QLDH.Entities
{
    [Serializable]
    public class Reward : ISearchable
    {
        public string RewardId { get; set; }
        public string RewardName { get; set; }
        public DateTime IssueDate { get; set; }
      
        // Lưu mã ID của Sinh viên hoặc Cán bộ được nhận thưởng
        public string StudentId { get; set; }


        public Reward()
        {
        }


        public Reward(string rewardId, string rewardName, DateTime issueDate, string studentId)
        {
            this.RewardId = rewardId;
            this.RewardName = rewardName;
            this.IssueDate = issueDate;
            this.StudentId = studentId;
        }
        
        public bool Matches(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return true;
            string k = keyword.ToLower();
            return RewardId?.ToLower().Contains(k) == true ||
                   RewardName?.ToLower().Contains(k) == true;
        }
    }
}