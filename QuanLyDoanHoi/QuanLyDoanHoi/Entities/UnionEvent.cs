using System;

namespace QuanLyDoanHoi.Entities
{
    [Serializable]
    public class UnionEvent
    {
        private string eventId;
        private string eventName;
        private double bonusScore;

        public string EventId { get { return eventId; } set { eventId = value; } } // ID [cite: 45]
        public string EventName { get { return eventName; } set { eventName = value; } } // TenSuKien [cite: 45]
        public double BonusScore { get { return bonusScore; } set { bonusScore = value; } } // DiemCong [cite: 45]

        public UnionEvent() { }
    }
}