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
        public static void SaveJsonFile(List<Human> list, string link)
        {
            JsonSerializerOptions install  = new JsonSerializerOptions();
            install.WriteIndented = true;

            string jsonString = JsonSerializer.Serialize(list, install);

            File.WriteAllText(link, jsonString);
        }

        // Hàm Đọc File
        public static List<Human> ReadJsonFile(string link)
        {
            if (File.Exists(link) == false)
            {
                return new List<Human>();
            }

            string jsonString = File.ReadAllText(link);

            JsonSerializerOptions install = new JsonSerializerOptions();

            List<Human> list = JsonSerializer.Deserialize<List<Human>>(jsonString, install);

            if (list == null)
            {
                return new List<Human>();
            }

            return  list;
        }
    }
}