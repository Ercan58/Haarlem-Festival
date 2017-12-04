using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}