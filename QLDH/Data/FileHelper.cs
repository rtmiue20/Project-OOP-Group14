using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using QLDH.Entities;

namespace QLDH.Data
{
    public static class FileHelper
    {
        private static readonly string DataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");

        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        private static string GetFilePath(string fileName)
        {
            if (!Directory.Exists(DataFolder))
                Directory.CreateDirectory(DataFolder);
            return Path.Combine(DataFolder, fileName);
        }

        public static void Save<T>(string fileName, List<T> list)
        {
            string path = GetFilePath(fileName);
            string json = JsonSerializer.Serialize(list, Options);
            File.WriteAllText(path, json);
        }

        public static List<T> Load<T>(string fileName)
        {
            string path = GetFilePath(fileName);
            if (!File.Exists(path))
                return new List<T>();
            string json = File.ReadAllText(path);
            List<T> result = JsonSerializer.Deserialize<List<T>>(json, Options);
            if (result == null)
                return new List<T>();
            return result;
        }
    }
}