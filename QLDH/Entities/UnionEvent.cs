using System;
using System.Collections.Generic;
using QLDH.Entities.Interface;


namespace QLDH.Entities
{
    [Serializable]
    public class UnionEvent : IComparable<UnionEvent>, ISearchable
    {
        private string eventId;
        private string eventName;
        private double bonusScore;
        private string address;

        public string EventId { get { return eventId; } set { eventId = value; } }
        public string EventName { get { return eventName; } set { eventName = value; } }
        public double BonusScore { get { return bonusScore; } set { bonusScore = value; } }
        public string Address { get { return address; } set { address = value; } }
         
        
        public UnionEvent() { }

        public List<ParticipationHistory> Participants { get; set; } = new List<ParticipationHistory>();
        
        public int CompareTo(UnionEvent? other)
        {
            if (other == null) return 1;
            return other.BonusScore.CompareTo(this.BonusScore); // Sắp xếp theo điểm thưởng
        }

        public bool Matches(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return true;
            string k = keyword.ToLower();
            return EventId?.ToLower().Contains(k) == true ||
                   EventName?.ToLower().Contains(k) == true;
        }
    }
}