using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace QLDH.Service
{
    public abstract class BaseManager<T> : IManager<T> 
    {
        // Khai báo delegate và event cho việc thay đổi dữ liệu
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        protected List<T> items;
        protected string filePath;

        protected virtual void OnDataChanged()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        protected BaseManager(string fileName)
        {
            this.items = new List<T>();
            string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }
            this.filePath = Path.Combine(dataFolder, fileName);
            LoadFromFile();
        }

        // Kỹ thuật Serialization: Ghi danh sách đối tượng ra file JSON
        protected void SaveToFile()
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions 
                { 
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                };
                string jsonString = JsonSerializer.Serialize(items, options);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi luu file: " + ex.Message);
            }
        }

        // Kỹ thuật Deserialization: Đọc ngược file JSON thành danh sách đối tượng C#
        protected void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(filePath);
                    if (string.IsNullOrWhiteSpace(jsonString))
                    {
                        items = new List<T>();
                        return;
                    }
                    
                    var options = new JsonSerializerOptions 
                    { 
                        PropertyNameCaseInsensitive = true
                    };

                    List<T> deserialized = JsonSerializer.Deserialize<List<T>>(jsonString, options);
                    if (deserialized != null)
                    {
                        items = deserialized;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi load file {filePath}: {ex.Message}");
                    this.items = new List<T>(); // Nếu file lỗi hoặc trống, tạo mới danh sách rỗng
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
            OnDataChanged();
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
            OnDataChanged();
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
            OnDataChanged();
        }

        public abstract List<T> Search(string keyword);
    }
}