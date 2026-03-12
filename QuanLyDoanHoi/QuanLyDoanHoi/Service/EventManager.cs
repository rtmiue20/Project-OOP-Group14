using System;
using System.Collections.Generic;
using QuanLyDoanHoi.Entities;

namespace QuanLyDoanHoi.Service
{
    public class EventManager : IManager<UnionEvent>
    {
        private List<UnionEvent> events;
        public EventManager()
        {
            events = new List<UnionEvent>();
        }
        public void Add(UnionEvent item)
        {
            events.Add(item);
        }

        public void Update(UnionEvent item)
        {
            for (int i = 0; i < events  .Count; i++)
            {
                if (events[i].EventId == item.EventId)
                {
                    events[i] = item;
                    break;
                }
            }
        }

        public void Delete(string id)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].EventId == id)
                {           
                    events.RemoveAt(i);
                    break;
                }
            }
        }

        public List<UnionEvent> GetAll()
        {
            return events;
        }

        public UnionEvent GetById(string id)
        {
            foreach (UnionEvent evt in events)
            {
                if (evt.EventId == id)
                {
                    return evt;
                }
            }
            return null;
        }

        public List<UnionEvent> Search(string keyword)
        {
            List<UnionEvent> result = new List<UnionEvent>();

            foreach (UnionEvent evt in events)
            {
                if (evt.EventId.Contains(keyword) || evt.EventName.Contains(keyword))
                {
                    result.Add(evt);
                }
            }

            return result;
        }
    }
}