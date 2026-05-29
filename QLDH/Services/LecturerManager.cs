using System.Collections.Generic;
using QLDH.Data;
using QLDH.Entities;

namespace QLDH.Service
{
    public class LecturerManager : BaseManager<Lecturer>
    {
        public LecturerManager() : base("lecturers.json")
        {
        }

        // 1. C - Create
        public override void Add(Lecturer item)
        {
            base.Add(item);
        }

        // 2. R - Read
        protected override string GetId(Lecturer item)
        {
            return item.LecturerId;
        }

        public override List<Lecturer> GetAll()
        {
            return items;
        }

        // 3. U - Update
        public override void Update(Lecturer item)
        {
            base.Update(item);
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
        }

        // Search function
        public override List<Lecturer> Search(string keyword)
        {
            List<Lecturer> result = new List<Lecturer>();
            foreach (Lecturer lec in items)
            {
                if (lec.LecturerId.Contains(keyword) || lec.FullName.Contains(keyword) || lec.Department.Contains(keyword))
                    result.Add(lec);
            }
            return result;
        }
    }
}