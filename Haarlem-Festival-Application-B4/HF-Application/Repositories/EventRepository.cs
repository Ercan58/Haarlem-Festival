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

        public List<DateList> GetAllHearEvents()
        {
            List<DateList> events = new List<DateList>
            {
                new DateList("26/07",
                    db.Jazzs.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 26).Date)
                    .Include(x => x.Location)
                    .ToList()),
                new DateList("27/07",
                    db.Jazzs.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 27).Date)
                    .Include(x => x.Location)
                    .ToList()),
                new DateList("28/07",
                    db.Jazzs.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 28).Date)
                    .Include(x => x.Location)
                    .ToList()),
                new DateList("29/07",
                    db.Jazzs.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 29).Date)
                    .Include(x => x.Location)
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

        public List<DateList> GetAllTasteEvents()
        {
            List<DateList> events = new List<DateList>
            {
                new DateList("26/07",
                    db.Diners.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 26).Date)
                    .Include(x => x.Restaurant)
                    .ToList()),
                new DateList("27/07",
                    db.Diners.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 27).Date)
                    .Include(x => x.Restaurant)
                    .ToList()),
                new DateList("28/07",
                    db.Diners.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 28).Date)
                    .Include(x => x.Restaurant)
                    .ToList()),
                new DateList("29/07",
                    db.Diners.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 29).Date)
                    .Include(x => x.Restaurant)
                    .ToList())
            };
            return events;
        }

        public Diner GetTasteEvent(int id)
        {
            Diner festivalEvent = db.Diners
                .Include(x => x.Restaurant)
                .Include(x => x.Restaurant.Location)
                .SingleOrDefault(x => x.ID == id);

            return festivalEvent;
        }

        public void UpdateTasteEvent(Diner festivalEvent)
        {
            db.Entry(festivalEvent).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<Location> GetHearLocations()
        {
            List<Location> locations = new List<Location>();
            foreach (var item in db.Jazzs
                    .Include(x => x.Location))
            {
                if (!locations.Contains(item.Location))
                {
                    locations.Add(item.Location);
                }
            }

            return locations;
        }

        public List<Location> GetTasteLocations()
        {
            List<Location> locations = new List<Location>();
            foreach (var item in db.Diners
                    .Include(x => x.Restaurant.Location))
            {
                if (!locations.Contains(item.Restaurant.Location))
                {
                    locations.Add(item.Restaurant.Location);
                }
            }

            return locations;
        }
    }
}