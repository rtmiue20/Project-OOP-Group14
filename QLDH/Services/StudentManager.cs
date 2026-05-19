using System.Collections.Generic;
using QLDH.Entities;

namespace QLDH.Service
{
    public class StudentManager : BaseManager<Student>
    {
        // 1. Chỉ cho BaseManager biết: "ID của Sinh viên chính là thuộc tính StudentId"
        protected override string GetId(Student item)
        {
            return item.StudentId;
        }

        // 2. Viết logic tìm kiếm riêng cho Sinh viên
        public override List<Student> Search(string keyword)
        {
            List<Student> result = new List<Student>();

            foreach (Student student in items)
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