using System;
using System.Collections.Generic;
using QLDH.Data;
using QLDH.Entities;

namespace QLDH.Service
{
    public class EventManager : BaseManager<UnionEvent>
    {
        private const string FileName = "events.json";
        private const string HistoryFileName = "participation.json";

        public EventManager()
        {
            items = FileHelper.Load<UnionEvent>(FileName);
        }

        // 1. C - Create
        public override void Add(UnionEvent item)
        {
            base.Add(item);
            FileHelper.Save<UnionEvent>(FileName, items);
        }

        // 2. R - Read
        protected override string GetId(UnionEvent item)
        {
            return item.EventId;
        }

        public override List<UnionEvent> GetAll()
        {
            return items;
        }

        // 3. U - Update
        public override void Update(UnionEvent item)
        {
            base.Update(item);
            FileHelper.Save<UnionEvent>(FileName, items);
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
            FileHelper.Save<UnionEvent>(FileName, items);
        }

        // Search function
        public override List<UnionEvent> Search(string keyword)
        {
            List<UnionEvent> result = new List<UnionEvent>();
            foreach (UnionEvent ev in items)
            {
                if (ev.EventId.Contains(keyword) || ev.EventName.Contains(keyword))
                    result.Add(ev);
            }
            return result;
        }

        // =========================================================================
        // LOGIC PHỨC TẠP: CRUD LỊCH SỬ THAM GIA & TÍNH ĐIỂM RÈN LUYỆN
        // =========================================================================

        // Lấy lịch sử tham gia của một sự kiện
        public List<ParticipationHistory> GetParticipantsByEvent(string eventId)
        {
            List<ParticipationHistory> allHistory = FileHelper.Load<ParticipationHistory>(HistoryFileName);
            List<ParticipationHistory> result = new List<ParticipationHistory>();
            foreach (ParticipationHistory ph in allHistory)
            {
                if (ph.EventIdReference == eventId)
                    result.Add(ph);
            }
            return result;
        }

        // Đăng ký tham gia + cộng điểm rèn luyện (Polymorphism)
        public void AddParticipation(ParticipationHistory history, Student student)
        {
            // 1. Lưu lịch sử tham gia
            List<ParticipationHistory> allHistory = FileHelper.Load<ParticipationHistory>(HistoryFileName);
            allHistory.Add(history);
            FileHelper.Save<ParticipationHistory>(HistoryFileName, allHistory);

            // 2. Tính điểm theo Đa hình (Polymorphism)
            // Lấy sự kiện để biết BonusScore
            UnionEvent targetEvent = null;
            foreach (UnionEvent ev in items)
            {
                if (ev.EventId == history.EventIdReference)
                {
                    targetEvent = ev;
                    break;
                }
            }

            if (targetEvent == null) return;

            // Gọi CalculateScore() - Polymorphism tự chọn đúng phiên bản
            // Official.CalculateScore() x1.2, Student.CalculateScore() x1.0
            student.CalculateScore(targetEvent);

            // 3. Cập nhật điểm sinh viên vào file
            UpdateStudentScore(student);
        }

        // Hủy tham gia + trừ điểm rèn luyện
        public void DeleteParticipation(string studentId, string eventId, Student student)
        {
            // 1. Xóa lịch sử
            List<ParticipationHistory> allHistory = FileHelper.Load<ParticipationHistory>(HistoryFileName);
            for (int i = 0; i < allHistory.Count; i++)
            {
                if (allHistory[i].StudentIdReference == studentId && allHistory[i].EventIdReference == eventId)
                {
                    allHistory.RemoveAt(i);
                    break;
                }
            }
            FileHelper.Save<ParticipationHistory>(HistoryFileName, allHistory);

            // 2. Trừ điểm
            UnionEvent targetEvent = null;
            foreach (UnionEvent ev in items)
            {
                if (ev.EventId == eventId)
                {
                    targetEvent = ev;
                    break;
                }
            }

            if (targetEvent == null) return;

            double deduction = targetEvent.BonusScore;
            // Cán bộ Đoàn được nhân 1.2 khi cộng nên khi trừ cũng phải trừ x1.2
            if (student is Official)
                deduction = targetEvent.BonusScore * 1.2;

            student.TrainingScore = Math.Max(0, student.TrainingScore - deduction);
            UpdateStudentScore(student);
        }

        // Cập nhật điểm sinh viên trong file students.json hoặc officials.json
        private void UpdateStudentScore(Student student)
        {
            if (student is Official)
            {
                List<Official> officials = FileHelper.Load<Official>("officials.json");
                for (int i = 0; i < officials.Count; i++)
                {
                    if (officials[i].StudentId == student.StudentId)
                    {
                        officials[i].TrainingScore = student.TrainingScore;
                        break;
                    }
                }
                FileHelper.Save<Official>("officials.json", officials);
            }
            else
            {
                List<Student> students = FileHelper.Load<Student>("students.json");
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].StudentId == student.StudentId)
                    {
                        students[i].TrainingScore = student.TrainingScore;
                        break;
                    }
                }
                FileHelper.Save<Student>("students.json", students);
            }
        }
    }
}