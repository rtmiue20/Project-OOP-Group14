using System;
using System.Collections.Generic;
using QLDH.Entities;


namespace QLDH.Service
{
   public class EventManager : BaseManager<UnionEvent>
   {
       public EventManager() : base("events.dat")
       {
       }


       public override List<UnionEvent> GetAll()
       {
           LoadFromFile();
           return this.items;
       }


       protected override string GetId(UnionEvent item)
       {
           return item.EventId;
       }


       public override List<UnionEvent> Search(string keyword)
       {
           List<UnionEvent> result = new List<UnionEvent>();
           foreach (UnionEvent ev in GetAll())
           {
               if (ev.EventId.Contains(keyword) || ev.EventName.Contains(keyword))
               {
                   result.Add(ev);
               }
           }
           return result;
       }


       // Logic Hoàn tác điểm rèn luyện xử lý thuần bằng Object File
       public void UndoScore(string studentId, double bonusScore)
       {
           // 1. Kiểm tra xem ID này có phải Sinh viên thường không
           StudentManager studentManager = new StudentManager();
           Student student = studentManager.GetById(studentId);
           if (student != null)
           {
               double curScore = student.TrainingScore;
               double newScore = curScore - bonusScore;
               if (newScore < 0)
               {
                   newScore = 0;
               }
               student.TrainingScore = newScore;
               studentManager.Update(student); // Tự động lưu lại vào file students.dat
               return; // Xử lý xong, ngắt hàm
           }


           // 2. Nếu không thấy ở sinh viên thường, tìm kiếm ở Cán bộ đoàn
           OfficialManager officialManager = new OfficialManager();
           Official official = officialManager.GetById(studentId);
           if (official != null)
           {
               double curScore = official.TrainingScore;
               double newScore = curScore - (bonusScore * 1.2); // Áp dụng hệ số 1.2 của cán bộ đoàn
               if (newScore < 0)
               {
                   newScore = 0;
               }
               official.TrainingScore = newScore;
               officialManager.Update(official); // Tự động lưu lại vào file officials.dat
           }
       }
   }
}
