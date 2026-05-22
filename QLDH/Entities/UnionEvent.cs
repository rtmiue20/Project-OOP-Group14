using System;
using System.Collections.Generic;



namespace QLDH.Entities
{
    [Serializable]
    public class UnionEvent
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
    }
}