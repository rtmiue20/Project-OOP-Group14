using System.Collections.Generic;
using QLDH.Data;
using QLDH.Entities;

namespace QLDH.Service
{
    public class ClubManager : BaseManager<Club>
    {
        private const string FileName = "clubs.json";

        public ClubManager()
        {
            items = FileHelper.Load<Club>(FileName);
        }

        // 1. C - Create
        public override void Add(Club item)
        {
            base.Add(item);
            FileHelper.Save<Club>(FileName, items);
        }

        // 2. R - Read
        protected override string GetId(Club item)
        {
            return item.ClubId;
        }

        public override List<Club> GetAll()
        {
            return items;
        }

        // 3. U - Update
        public override void Update(Club item)
        {
            base.Update(item);
            FileHelper.Save<Club>(FileName, items);
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
            FileHelper.Save<Club>(FileName, items);
        }

        // Search function
        public override List<Club> Search(string keyword)
        {
            List<Club> result = new List<Club>();
            foreach (Club club in items)
            {
                if (club.ClubId.Contains(keyword) || club.ClubName.Contains(keyword))
                    result.Add(club);
            }
            return result;
        }
    }
}