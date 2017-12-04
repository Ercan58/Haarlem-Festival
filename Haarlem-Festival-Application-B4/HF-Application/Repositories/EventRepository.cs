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

        public List<HearDateList> GetAllHearEvents()
        {
            List<HearDateList> events = new List<HearDateList>
            {
                new HearDateList("26/07", db.Jazzs.OrderBy(i => i.StartDate).Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 26).Date).ToList()),
                new HearDateList("27/07", db.Jazzs.OrderBy(i => i.StartDate).Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 27).Date).ToList()),
                new HearDateList("28/07", db.Jazzs.OrderBy(i => i.StartDate).Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 28).Date).ToList()),
                new HearDateList("29/07", db.Jazzs.OrderBy(i => i.StartDate).Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 29).Date).ToList())
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