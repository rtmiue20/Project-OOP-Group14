using System.Collections.Generic;

namespace QLDH.Service
{
    public abstract class BaseManager<T> : IManager<T>
    {
        protected List<T> items;

        public BaseManager()
        {
            items = new List<T>();
        }

        // Vì 'T' chưa biết ID tên là gì (StudentId hay EventId)
        // Nên ta bắt buộc các lớp con phải tự định nghĩa cách lấy ID
        protected abstract string GetId(T item);

        public abstract List<T> Search(string keyword);

        public virtual void Add(T item)
        {
            items.Add(item);
        }

        public virtual void Delete(string id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (GetId(items[i]) == id)
                {
                    items.RemoveAt(i);
                    break;
                }
            }
        }

        public virtual void Update(T item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (GetId(items[i]) == GetId(item))
                {
                    items[i] = item;
                    break;
                }
            }
        }

        public virtual T? GetById(string id)
        {
            foreach (T item in items)
            {
                if (GetId(item) == id)
                {
                    return item;
                }
            }
            return default; // = return null
        }

        public virtual List<T> GetAll()
        {
            return items;
        }
    }
}