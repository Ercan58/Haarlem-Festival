using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models.Repositories
{
    public class EventRepository : IEventRepository
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        public IEnumerable<FestivalEvent> GetAllEvents()
        {
            IEnumerable<FestivalEvent> events = db.Events;

            return events;
        }
    }
}