using System;

namespace QuanLyDoanHoi.Entities
{
    [Serializable]
    public class UnionEvent
    {
        private string eventId;
        private string eventName;
        private double bonusScore;

        public string EventId { get { return eventId; } set { eventId = value; } }
        public string EventName { get { return eventName; } set { eventName = value; } }
        public double BonusScore { get { return bonusScore; } set { bonusScore = value; } }

        public UnionEvent() { }
    }
}