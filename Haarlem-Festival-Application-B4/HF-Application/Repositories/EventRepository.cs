using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Collections;
using HF_Application.Models.Events;

namespace HF_Application.Models
{
    public class EventRepository : IEventRepository
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        public List<HearDateList> GetAllHearEvents()
        {
            List<HearDateList> events = new List<HearDateList>
            {
                new HearDateList("26/07",
                    db.Jazzs.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 26).Date)
                    .Include(x => x.Location)
                    .Include(x => x.Band)
                    .ToList()),
                new HearDateList("27/07",
                    db.Jazzs.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 27).Date)
                    .Include(x => x.Location)
                    .Include(x => x.Band)
                    .ToList()),
                new HearDateList("28/07",
                    db.Jazzs.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 28).Date)
                    .Include(x => x.Location)
                    .Include(x => x.Band)
                    .ToList()),
                new HearDateList("29/07",
                    db.Jazzs.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 29).Date)
                    .Include(x => x.Location)
                    .Include(x => x.Band)
                    .ToList())
            };
            return events;
        }

        public Jazz GetHearEvent(int id)
        {
            Jazz festivalEvent = db.Jazzs.Find(id);

            return festivalEvent;
        }

        public void UpdateHearEvent(Jazz festivalEvent)
        {
            db.Entry(festivalEvent).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<TasteDateList> GetAllTasteEvents()
        {
            List<TasteDateList> events = new List<TasteDateList>
            {
                new TasteDateList("26/07",
                    db.Diners.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 26).Date)
                    .Include(x => x.Location)
                    .Include(x => x.Restaurant)
                    .ToList()),
                new TasteDateList("27/07",
                    db.Diners.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 27).Date)
                    .Include(x => x.Location)
                    .Include(x => x.Restaurant)
                    .ToList()),
                new TasteDateList("28/07",
                    db.Diners.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 28).Date)
                    .Include(x => x.Location)
                    .Include(x => x.Restaurant)
                    .ToList()),
                new TasteDateList("29/07",
                    db.Diners.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 29).Date)
                    .Include(x => x.Location)
                    .Include(x => x.Restaurant)
                    .ToList())
            };
            return events;
        }

        public Diner GetTasteEvent(int id)
        {
            Diner festivalEvent = db.Diners.Include(x => x.Location).SingleOrDefault(x => x.ID == id);

            return festivalEvent;
        }

        public void UpdateTasteEvent(Diner festivalEvent)
        {
            db.Entry(festivalEvent).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<Location> GetLocations()
        {
            List<Location> locations = db.Locations.ToList();

            return locations;

        }
    }
}