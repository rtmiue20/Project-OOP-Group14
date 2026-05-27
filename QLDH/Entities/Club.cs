using System;


namespace QLDH.Entities
{
    [Serializable]
    public class Club
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
    }
}