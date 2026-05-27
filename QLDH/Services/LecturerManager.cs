using System;
using System.Collections.Generic;
using QLDH.Entities;


namespace QLDH.Service
{
    public class LecturerManager : BaseManager<Lecturer>
    {
        public LecturerManager() : base("lecturers.dat")
        {
        }


        public override List<Lecturer> GetAll()
        {
            LoadFromFile();
            return this.items;
        }


        protected override string GetId(Lecturer item)
        {
            return item.LecturerId;
        }


        public override List<Lecturer> Search(string keyword)
        {
            List<Lecturer> result = new List<Lecturer>();
            foreach (Lecturer lec in GetAll())
            {
                if (lec.LecturerId.Contains(keyword) || lec.FullName.Contains(keyword) || lec.Department.Contains(keyword))
                {
                    result.Add(lec);
                }
            }
            return result;
        }
    }
}