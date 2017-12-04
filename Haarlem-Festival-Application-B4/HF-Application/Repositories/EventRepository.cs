using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Collections;

namespace HF_Application.Models
{
    public class EventRepository : IEventRepository
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        public IEnumerable<HearDateList> GetAllHearEvents()
        {
            List<HearDateList> events = new List<HearDateList>
            {
                new HearDateList("26/07/2018", db.Jazzs.OrderBy(i => i.StartDate).Where(i => i.StartDate.Date == DateTime.Parse("26/07/2018"))),
                new HearDateList("27/07/2018", db.Jazzs.OrderBy(i => i.StartDate).Where(i => i.StartDate.Date == DateTime.Parse("27/07/2018"))),
                new HearDateList("28/07/2018", db.Jazzs.OrderBy(i => i.StartDate).Where(i => i.StartDate.Date == DateTime.Parse("28/07/2018"))),
                new HearDateList("29/07/2018", db.Jazzs.OrderBy(i => i.StartDate).Where(i => i.StartDate.Date == DateTime.Parse("29/07/2018")))
            };
            return events;
        }

        public FestivalEvent GetEvent(int id)
        {
            FestivalEvent festivalEvent = db.FestivalEvent.Find(id);

            return festivalEvent;
        }
    }
}