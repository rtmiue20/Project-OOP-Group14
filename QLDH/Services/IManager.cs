
using System.Collections.Generic;

namespace QLDH.Service
{
    public interface IManager<T>
    {
        void Add(T item);
        void Delete(string id);
        void Update(T item);
        T? GetById(string id); // thêm ? vì C# mặc định hiểu là "Bắt buộc phải trả về 1 sinh viên có thật" 
        List<T> GetAll();
        List<T> Search(string keyword);
    }
}
