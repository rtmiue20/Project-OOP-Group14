using System;

namespace QuanLyDoanHoi.Entities
{
    [Serializable]
    public class ParticipationHistory
    {
        private DateTime checkInTime;
        private string status;
        private string studentIdReference; // Chứa ID Sinh viên [cite: 48]
        private string eventIdReference;   // Chứa ID Sự kiện [cite: 48]

        public DateTime CheckInTime { get { return checkInTime; } set { checkInTime = value; } } // ThoiGianCheckIn [cite: 47]
        public string Status { get { return status; } set { status = value; } } // TrangThai [cite: 47]
        public string StudentIdReference { get { return studentIdReference; } set { studentIdReference = value; } }
        public string EventIdReference { get { return eventIdReference; } set { eventIdReference = value; } }

        public ParticipationHistory() { }
    }
}