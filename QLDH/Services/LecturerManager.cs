using System.Collections.Generic;
using QLDH.Entities;

namespace QLDH.Service
{
    public class LecturerManager : BaseManager<Lecturer>
    {
        // Lấy ID của Giảng viên
        protected override string GetId(Lecturer item)
        {
            return item.LecturerId;
        }

        // Logic tìm kiếm riêng cho Giảng viên
        public override List<Lecturer> Search(string keyword)
        {
            List<Lecturer> result = new List<Lecturer>();

            foreach (Lecturer lec in items)
            {
                // Tìm theo Mã giảng viên hoặc Họ tên
                if (lec.LecturerId.Contains(keyword) || lec.FullName.Contains(keyword))
                {
                    result.Add(lec);
                }
            }
            return result;
        }
    }
}