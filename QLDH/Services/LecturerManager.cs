using System.Collections.Generic;
using QLDH.Data;
using QLDH.Entities;

namespace QLDH.Service
{
    public class LecturerManager : BaseManager<Lecturer>
    {
        private const string FileName = "lecturers.json";

        public LecturerManager()
        {
            items = FileHelper.Load<Lecturer>(FileName);
        }

        // 1. C - Create
        public override void Add(Lecturer item)
        {
            base.Add(item);
            FileHelper.Save<Lecturer>(FileName, items);
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
            FileHelper.Save<Lecturer>(FileName, items);
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
            FileHelper.Save<Lecturer>(FileName, items);
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