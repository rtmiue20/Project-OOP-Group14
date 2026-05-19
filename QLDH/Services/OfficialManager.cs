using System.Collections.Generic;
using QLDH.Entities;

namespace QLDH.Service
{
    public class OfficialManager : BaseManager<Official>
    {
        // Cán bộ Đoàn vẫn dùng StudentId làm mã định danh
        protected override string GetId(Official item)
        {
            return item.StudentId;
        }

        // Logic tìm kiếm riêng cho Cán bộ Đoàn
        public override List<Official> Search(string keyword)
        {
            List<Official> result = new List<Official>();

            foreach (Official off in items)
            {
                if (off.StudentId.Contains(keyword) || off.FullName.Contains(keyword))
                {
                    result.Add(off);
                }
            }
            return result;
        }
    }
}