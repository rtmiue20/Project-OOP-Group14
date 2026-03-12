using System;
using System.Collections.Generic;
using QuanLyDoanHoi.Entities;

namespace QuanLyDoanHoi.Service
{
    public class OfficialManager : IManager<Official>
    {
        private List<Official> officials;
        public OfficialManager()
        {
            officials = new List<Official>();
        }

        public void Add(Official item)
        {
            officials.Add(item);
        }

        public void Update(Official item)
        {
            for (int i = 0; i < officials.Count; i++)
            {
                if (officials[i].StudentId == item.StudentId)
                {
                    officials[i] = item;
                    break;
                }
            }
        }

        public void Delete(string id)
        {
            for (int i = 0; i < officials.Count; i++)
            {
                if (officials[i].StudentId == id)
                {
                    officials.RemoveAt(i);
                    break;
                }
            }
        }

        public List<Official> GetAll()
        {
            return officials;
        }

        public Official GetById(string id)
        {
            foreach (Official off in officials)
            {
                if (off.StudentId == id)
                {
                    return off;
                }
            }
            return null;
        }

        public List<Official> Search(string keyword)
        {
            List<Official> result = new List<Official>();

            foreach (Official off in officials)
            {
                if (off.StudentId.Contains(keyword) || off.FullName.Contains(keyword))
                {
                    result.Add(off);
                }
            }
            return result;
        }
    }
}