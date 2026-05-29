using System;
using QLDH.Entities.Interface;


namespace QLDH.Entities
{
    [Serializable]
    public class Club : ISearchable
    {
        public string ClubId { get; set; }
        public string ClubName { get; set; }
        public DateTime FoundedDate { get; set; }
        public int MemberCount { get; set; }


        // Constructor mặc định
        public Club()
        {
        }


        // Constructor có tham số
        public Club(string clubId, string clubName, DateTime foundedDate, int memberCount)
        {
            this.ClubId = clubId;
            this.ClubName = clubName;
            this.FoundedDate = foundedDate;
            this.MemberCount = memberCount;
        }
        
        public int CompareTo(Club? other)
        {
            if (other == null) return 1;
            return other.MemberCount.CompareTo(this.MemberCount);
        }

        public bool Matches(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return true;
            string k = keyword.ToLower();
            return ClubId?.ToLower().Contains(k) == true ||
                   ClubName?.ToLower().Contains(k) == true;
        }
    }
}