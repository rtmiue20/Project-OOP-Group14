using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using QuanLyDoanHoi.Entities;

namespace QuanLyDoanHoi.Data
{
    // Lớp xử lý File
    public class FileHelper
    {
        // Hàm Ghi File 
        public static void SaveJsonFile<T>(List<T> list, string link)
        {
            JsonSerializerOptions install = new JsonSerializerOptions();
            install.WriteIndented = true;
            string jsonString = JsonSerializer.Serialize(list, install);
            File.WriteAllText(link, jsonString);
        }

        // Hàm Đọc File 
        public static List<T> ReadJsonFile<T>(string link)
        {
            if (File.Exists(link) == false)
            {
                return new List<T>();
            }
            string jsonString = File.ReadAllText(link);
            JsonSerializerOptions install = new JsonSerializerOptions();

            List<T> list = JsonSerializer.Deserialize<List<T>>(jsonString, install);

            if (list == null)
            {
                return new List<T>();
            }

            return list;
        }
    }
}