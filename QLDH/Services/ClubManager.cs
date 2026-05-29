using System.Collections.Generic;
using QLDH.Data;
using QLDH.Entities;

namespace QLDH.Service
{
    public class ClubManager : BaseManager<Club>
    {
        public ClubManager() : base("clubs.json")
        {
        }

        // 1. C - Create
        public override void Add(Club item)
        {
            base.Add(item);
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
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
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