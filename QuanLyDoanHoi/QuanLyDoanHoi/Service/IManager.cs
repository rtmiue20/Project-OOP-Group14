
using System.Collections.Generic;

namespace QuanLyDoanHoi.Service
{
    public interface IManager<T>
    {
        void Add(T item);
        void Delete(string id);
        void Update(T item);
        T GetById(string id);
        List<T> GetAll();
    }
}
