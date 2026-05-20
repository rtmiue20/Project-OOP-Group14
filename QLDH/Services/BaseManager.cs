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

        // 1. C - Create
        public virtual void Add(T item)
        {
            items.Add(item);
        }

        // 2. R - Read
        public abstract List<T> GetAll();
        protected abstract string GetId(T item);
        public virtual T? GetById(string id)
        {
            foreach (T item in items)
            {
                if (GetId(item) == id)
                {
                    return item;
                }
            }
            return default;
        }
        
        // 3. U - Update
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
        
        // 4. D - Delete
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

        // Search function
        public abstract List<T> Search(string keyword);
    }
    
}