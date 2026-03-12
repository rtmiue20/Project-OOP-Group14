using System;
using System.Collections.Generic;
using QuanLyDoanHoi.Entities;

namespace QuanLyDoanHoi.Service
{
    public class LecturerManager : IManager<Lecturer>
    {
        private List<Lecturer> lecturers;

        public LecturerManager()
        {
            lecturers = new List<Lecturer>();
        }

        public void Add(Lecturer item)
        {
            lecturers.Add(item);
        }

        public void Update(Lecturer item)
        {
            for (int i = 0; i < lecturers.Count; i++)
            {
                // Tìm theo LecturerId
                if (lecturers[i].LecturerId == item.LecturerId)
                {
                    lecturers[i] = item;
                    break;
                }
            }
        }

        public void Delete(string id)
        {
            for (int i = 0; i < lecturers.Count; i++)
            {
                if (lecturers[i].LecturerId == id)
                {
                    lecturers.RemoveAt(i);
                    break;
                }
            }
        }

        public List<Lecturer> GetAll()
        {
            return lecturers;
        }

        public Lecturer GetById(string id)
        {
            foreach (Lecturer lec in lecturers)
            {
                if (lec.LecturerId == id)
                {
                    return lec;
                }
            }
            return null;
        }

        public List<Lecturer> Search(string keyword)
        {
            List<Lecturer> result = new List<Lecturer>();
            foreach (Lecturer lec in lecturers)
            {
                // Tìm theo Mã Giảng viên hoặc Tên (Kế thừa từ class Human)
                if (lec.LecturerId.Contains(keyword) || lec.FullName.Contains(keyword))
                {
                    result.Add(lec);
                }
            }
            return result;
        }
    }
}