using System.Collections.Generic;
using QLDH.Data;
using QLDH.Entities;

namespace QLDH.Service
{
    public class StudentManager : BaseManager<Student>
    {
        public StudentManager() : base("students.json")
        {
        }

        // 1. C - Create
        public override void Add(Student item)
        {
            base.Add(item);
        }

        // 2. R - Read
        protected override string GetId(Student item)
        {
            return item.StudentId;
        }

        public override List<Student> GetAll()
        {
            return items;
        }

        // 3. U - Update
        public override void Update(Student item)
        {
            base.Update(item);
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
        }

        // Search function
        public override List<Student> Search(string keyword)
        {
            List<Student> result = new List<Student>();
            foreach (Student st in items)
            {
                if (st.StudentId.Contains(keyword) || st.FullName.Contains(keyword) || st.ClassName.Contains(keyword))
                    result.Add(st);
            }
            return result;
        }
    }
}