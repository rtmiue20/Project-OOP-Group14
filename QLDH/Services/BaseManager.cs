using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QLDH.Service
{
    public abstract class BaseManager<T> : IManager<T>
    {
        protected List<T> items;
        protected string filePath;

        public BaseManager(string filePath)
        {
            this.items = new List<T>();
            this.filePath = filePath;
            LoadFromFile(); // Tự động load dữ liệu lên khi khởi tạo manager
        }

        // Kỹ thuật Serialization: Ghi danh sách đối tượng ra file nhị phân (.dat)
        protected void SaveToFile()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, items);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi luu file: " + ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close(); // Đóng stream để giải phóng tài nguyên hệ thống
                }
            }
        }

        // Kỹ thuật Deserialization: Đọc ngược file nhị phân thành danh sách đối tượng C#
        protected void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<T> deserialized = (List<T>)formatter.Deserialize(fs);
                    if (deserialized != null)
                    {
                        items = deserialized;
                    }
                }
                catch (Exception ex)
                {
                    this.items = new List<T>(); // Nếu file lỗi hoặc trống, tạo mới danh sách rỗng
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close(); // Đóng luồng đọc file
                    }
                }
            }
            else
            {
                this.items = new List<T>();
            }
        }

        public virtual void Add(T item)
        {
            LoadFromFile();
            items.Add(item);
            SaveToFile();
        }

        public abstract List<T> GetAll();
        protected abstract string GetId(T item);

        public virtual T GetById(string id)
        {
            LoadFromFile();
            foreach (T item in items)
            {
                if (GetId(item) == id)
                {
                    return item;
                }
            }
            return default(T);
        }

        public virtual void Update(T item)
        {
            LoadFromFile();
            for (int i = 0; i < items.Count; i++)
            {
                if (GetId(items[i]) == GetId(item))
                {
                    items[i] = item;
                    break;
                }
            }
            SaveToFile();
        }

        public virtual void Delete(string id)
        {
            LoadFromFile();
            for (int i = 0; i < items.Count; i++)
            {
                if (GetId(items[i]) == id)
                {
                    items.RemoveAt(i);
                    break;
                }
            }
            SaveToFile();
        }

        public abstract List<T> Search(string keyword);
    }
}