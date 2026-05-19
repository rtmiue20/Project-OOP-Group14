using System.Collections.Generic;
using QLDH.Entities;

namespace QLDH.Service
{
    public class EventManager : BaseManager<UnionEvent>
    {
        // Chỉ cho BaseManager biết cách lấy ID của Sự kiện
        protected override string GetId(UnionEvent item)
        {
            return item.EventId;
        }

        // Logic tìm kiếm riêng cho Sự kiện
        public override List<UnionEvent> Search(string keyword)
        {
            List<UnionEvent> result = new List<UnionEvent>();

            foreach (UnionEvent evt in items)
            {
                // Tìm theo Mã sự kiện hoặc Tên sự kiện
                if (evt.EventId.Contains(keyword) || evt.EventName.Contains(keyword))
                {
                    result.Add(evt);
                }
            }
            return result;
        }
    }
}