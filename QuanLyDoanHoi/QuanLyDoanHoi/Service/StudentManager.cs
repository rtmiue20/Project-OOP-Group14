using Microsoft.VisualBasic.Devices;
using QuanLyDoanHoi.Entities;
using System;
using System.Collections.Generic;

namespace QuanLyDoanHoi.Service
{
    public class StudentManager : IManager<Student>
    {
        private List<Student> students;
        public StudentManager()
        {
            students = new List<Student>();
        }
        // Thêm, xóa, sửa, tìm kiếm sinh viên
        public void Add(Student item)
        {
            students.Add(item);
        }

        public void Delete(string id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentId == id)
                {
                    students.RemoveAt(i);
                    break;
                }
            }
        }

        public void Update(Student item)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentId == item.StudentId)
                {
                    students[i] = item;
                    break;
                }
            }
        }

        public Student GetById(string id)
        {
            foreach (Student student in students)
            {
                if (student.StudentId == id)
                {
                    return student;
                }
            }
            return null;
        }
        public List<Student> GetAll()
        {
            return students;
        }

        public List<Student> Search(string keyword)
        {
            List<Student> result = new List<Student>();
            foreach (Student student in students)
            {
                if (student.StudentId.Contains(keyword) || student.FullName.Contains(keyword))
                {
                    result.Add(student);
                }
            }

            return result;
        }
    }
}
