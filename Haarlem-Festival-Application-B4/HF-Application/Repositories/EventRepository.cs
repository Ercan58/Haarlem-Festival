using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;

namespace HF_Application.Models
{
    public class EventRepository : IEventRepository
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        public IEnumerable<FestivalEvent> GetAllEvents()
        {
            IEnumerable<FestivalEvent> events = db.FestivalEvent;

            return events;
        }

        public FestivalEvent GetEvent(int id)
        {
            FestivalEvent festivalEvent = db.FestivalEvent.Find(id);

            return festivalEvent;
        }
    }
}