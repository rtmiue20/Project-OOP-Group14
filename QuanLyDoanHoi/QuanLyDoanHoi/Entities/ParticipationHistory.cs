using System;

namespace QuanLyDoanHoi.Entities
{
    [Serializable]
    public class ParticipationHistory
    {
        private DateTime checkInTime;
        private string status;
        private string studentIdReference; // Chứa ID Sinh viên
        private string eventIdReference;   // Chứa ID Sự kiện 

        public DateTime CheckInTime { get { return checkInTime; } set { checkInTime = value; } } // ThoiGianCheckIn
        public string Status { get { return status; } set { status = value; } } // TrangThai
        public string StudentIdReference { get { return studentIdReference; } set { studentIdReference = value; } }
        public string EventIdReference { get { return eventIdReference; } set { eventIdReference = value; } }

        public ParticipationHistory() { }
    }
}