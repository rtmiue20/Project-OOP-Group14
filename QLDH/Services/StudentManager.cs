using System;
using System.Collections.Generic;
using QLDH.Entities;

namespace QLDH.Service
{
    public class StudentManager : BaseManager<Student>
    {
        public StudentManager() : base("students.dat")
        {
        }

        public override List<Student> GetAll()
        {
            LoadFromFile();
            return this.items;
        }

        protected override string GetId(Student item)
        {
            return item.StudentId;
        }

        public override List<Student> Search(string keyword)
        {
            List<Student> result = new List<Student>();
            foreach (Student st in GetAll())
            {
                if (st.StudentId.Contains(keyword) || st.FullName.Contains(keyword) || st.ClassName.Contains(keyword))
                {
                    result.Add(st);
                }
            }
            return result;
        }
    }
}