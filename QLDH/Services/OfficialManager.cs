using System;
using System.Collections.Generic;
using QLDH.Entities;


namespace QLDH.Service
{
    public class OfficialManager : BaseManager<Official>
    {
        public OfficialManager() : base("officials.dat")
        {
        }


        public override List<Official> GetAll()
        {
            LoadFromFile();
            return this.items;
        }


        protected override string GetId(Official item)
        {
            return item.StudentId;
        }


        public override List<Official> Search(string keyword)
        {
            List<Official> result = new List<Official>();
            foreach (Official off in GetAll())
            {
                if (off.StudentId.Contains(keyword) || off.FullName.Contains(keyword) || off.ClassName.Contains(keyword))
                {
                    result.Add(off);
                }
            }
            return result;
        }
    }
}