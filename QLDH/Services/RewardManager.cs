using System.Collections.Generic;
using QLDH.Data;
using QLDH.Entities;

namespace QLDH.Service
{
    public class RewardManager : BaseManager<Reward>
    {
        private const string FileName = "rewards.json";

        public RewardManager()
        {
            items = FileHelper.Load<Reward>(FileName);
        }

        // 1. C - Create
        public override void Add(Reward item)
        {
            base.Add(item);
            FileHelper.Save<Reward>(FileName, items);
        }

        // 2. R - Read
        protected override string GetId(Reward item)
        {
            return item.RewardId;
        }

        public override List<Reward> GetAll()
        {
            return items;
        }

        // 3. U - Update
        public override void Update(Reward item)
        {
            base.Update(item);
            FileHelper.Save<Reward>(FileName, items);
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
            FileHelper.Save<Reward>(FileName, items);
        }

        // Search function
        public override List<Reward> Search(string keyword)
        {
            List<Reward> result = new List<Reward>();
            foreach (Reward r in items)
            {
                if (r.RewardId.Contains(keyword) || r.RewardName.Contains(keyword) || r.StudentId.Contains(keyword))
                    result.Add(r);
            }
            return result;
        }

        // Lấy tất cả khen thưởng của một sinh viên
        public List<Reward> GetByStudent(string studentId)
        {
            List<Reward> result = new List<Reward>();
            foreach (Reward r in items)
            {
                if (r.StudentId == studentId)
                    result.Add(r);
            }
            return result;
        }
    }
}