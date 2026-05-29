using System.Collections.Generic;
using QLDH.Data;
using QLDH.Entities;

namespace QLDH.Service
{
    public class FacultyManager : BaseManager<Faculty>
    {
        public FacultyManager() : base("faculties.json")
        {
        }

        // 1. C - Create
        public override void Add(Faculty item)
        {
            base.Add(item);
        }

        // 2. R - Read
        protected override string GetId(Faculty item)
        {
            return item.FacultyId;
        }

        public override List<Faculty> GetAll()
        {
            return items;
        }

        // 3. U - Update
        public override void Update(Faculty item)
        {
            base.Update(item);
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
        }

        // Search function
        public override List<Faculty> Search(string keyword)
        {
            List<Faculty> result = new List<Faculty>();
            foreach (Faculty fac in items)
            {
                if (fac.FacultyId.Contains(keyword) || fac.FacultyName.Contains(keyword) || fac.DeanName.Contains(keyword))
                    result.Add(fac);
            }
            return result;
        }
    }
}