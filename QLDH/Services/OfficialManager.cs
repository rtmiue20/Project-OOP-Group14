using System.Collections.Generic;
using QLDH.Data;
using QLDH.Entities;

namespace QLDH.Service
{
    public class OfficialManager : BaseManager<Official>
    {
        private const string FileName = "officials.json";

        public OfficialManager()
        {
            items = FileHelper.Load<Official>(FileName);
        }

        // 1. C - Create
        public override void Add(Official item)
        {
            base.Add(item);
            FileHelper.Save<Official>(FileName, items);
        }

        // 2. R - Read
        protected override string GetId(Official item)
        {
            return item.StudentId;
        }

        public override List<Official> GetAll()
        {
            return items;
        }

        // 3. U - Update
        public override void Update(Official item)
        {
            base.Update(item);
            FileHelper.Save<Official>(FileName, items);
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
            FileHelper.Save<Official>(FileName, items);
        }

        // Search function
        public override List<Official> Search(string keyword)
        {
            List<Official> result = new List<Official>();
            foreach (Official off in items)
            {
                if (off.StudentId.Contains(keyword) || off.FullName.Contains(keyword) || off.ClassName.Contains(keyword))
                    result.Add(off);
            }
            return result;
        }
    }
}