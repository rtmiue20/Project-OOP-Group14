using System;


namespace QLDH.Entities
{
    [Serializable]
    public class Reward
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
    }
}