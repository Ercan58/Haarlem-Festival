using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Collections;
using System.Web.Mvc;
using HF_Application.Models.Events;
using System.IO;

namespace HF_Application.Models
{
    public class EventRepository : IEventRepository
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        // Hear events
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

        public Jazz GetHearEvent(int? id)
        {
            Jazz festivalEvent = db.Jazzs.Find(id);

            return festivalEvent;
        }

        public void AddHearEvent(Jazz festivalEvent)
        {
            db.Jazzs.Add(festivalEvent);
            db.SaveChanges();
        }

        public void UpdateHearEvent(Jazz festivalEvent)
        {
            db.Entry(festivalEvent).State = EntityState.Modified;
            db.SaveChanges();
        }

        // Taste events
        public List<DateList> GetAllTasteEvents()
        {
            List<DateList> events = new List<DateList>
            {
                new DateList("26/07",
                    db.Diners.OrderBy(i => i.RestaurantId)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 26).Date)
                    .Include(x => x.Restaurant)
                    .ToList()),
                new DateList("27/07",
                    db.Diners.OrderBy(i => i.RestaurantId)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 27).Date)
                    .Include(x => x.Restaurant)
                    .ToList()),
                new DateList("28/07",
                    db.Diners.OrderBy(i => i.RestaurantId)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 28).Date)
                    .Include(x => x.Restaurant)
                    .ToList()),
                new DateList("29/07",
                    db.Diners.OrderBy(i => i.RestaurantId)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 29).Date)
                    .Include(x => x.Restaurant)
                    .ToList())
            };
            return events;
        }

        public List<Restaurant> GetTasteLocations()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var item in db.Diners
                    .Include(x => x.Restaurant))
            {
                if (!restaurants.Contains(item.Restaurant))
                {
                    restaurants.Add(item.Restaurant);
                }
            }

            return restaurants;
        }

        public Restaurant GetRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);

            return restaurant;
        }

        public Diner GetTasteEvent(int? id)
        {
            Diner festivalEvent = db.Diners
                .Include(x => x.Restaurant)
                .Include(x => x.Restaurant.Location)
                .SingleOrDefault(x => x.ID == id);

            return festivalEvent;
        }

        public void AddTasteEvent(Diner festivalEvent)
        {
            db.Diners.Add(festivalEvent);
            db.SaveChanges();
        }
        public void UpdateTasteEvent(Diner festivalEvent)
        {
            db.Entry(festivalEvent).State = EntityState.Modified;
            db.SaveChanges();
        }

        // See events
        public List<DateList> GetAllSeeEvents()
        {
            List<DateList> events = new List<DateList>
            {
                new DateList("26/07",
                    db.Historics.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 26).Date)
                    .Include(x => x.Location)
                    .ToList()),
                new DateList("27/07",
                    db.Historics.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 27).Date)
                    .Include(x => x.Location)
                    .ToList()),
                new DateList("28/07",
                    db.Historics.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 28).Date)
                    .Include(x => x.Location)
                    .ToList()),
                new DateList("29/07",
                    db.Historics.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 29).Date)
                    .Include(x => x.Location)
                    .ToList())
            };
            return events;
        }

        public List<Location> GetSeeLocations()
        {
            List<Location> locations = new List<Location>();
            foreach (var item in db.Historics
                    .Include(x => x.Location))
            {
                if (!locations.Contains(item.Location))
                {
                    locations.Add(item.Location);
                }
            }

            return locations;
        }

        public Historic GetSeeEvent(int? id)
        {
            Historic festivalEvent = db.Historics.Find(id);

            return festivalEvent;
        }

        public void AddSeeEvent(Historic festivalEvent)
        {
            db.Historics.Add(festivalEvent);
            db.SaveChanges();
        }
        public void UpdateSeeEvent(Historic festivalEvent)
        {
            db.Entry(festivalEvent).State = EntityState.Modified;
            db.SaveChanges();
        }

        // Talk events
        public List<DateList> GetAllTalkEvents()
        {
            List<DateList> events = new List<DateList>
            {
                new DateList("26/07",
                    db.Talks.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 26).Date)
                    .Include(x => x.Location)
                    .ToList()),
                new DateList("27/07",
                    db.Talks.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 27).Date)
                    .Include(x => x.Location)
                    .ToList()),
                new DateList("28/07",
                    db.Talks.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 28).Date)
                    .Include(x => x.Location)
                    .ToList()),
                new DateList("29/07",
                    db.Talks.OrderBy(i => i.StartDate)
                    .Where(x => DbFunctions.TruncateTime(x.StartDate) == new DateTime(2018, 07, 29).Date)
                    .Include(x => x.Location)
                    .ToList())
            };
            return events;
        }

        public List<Location> GetTalkLocations()
        {
            List<Location> locations = new List<Location>();
            foreach (var item in db.Talks
                    .Include(x => x.Location))
            {
                if (!locations.Contains(item.Location))
                {
                    locations.Add(item.Location);
                }
            }

            return locations;
        }

        public Talk GetTalkEvent(int? id)
        {
            Talk festivalEvent = db.Talks.Find(id);

            return festivalEvent;
        }

        public void AddTalkEvent(Talk festivalEvent)
        {
            db.Talks.Add(festivalEvent);
            db.SaveChanges();
        }
        public void UpdateTalkEvent(Talk festivalEvent)
        {
            db.Entry(festivalEvent).State = EntityState.Modified;
            db.SaveChanges();
        }
        public List<TalkQuestion> GetAllTalkQuestions()
        {
            List<TalkQuestion> questions = db.OrderItems
                .Include(x => x.Item)
                .OrderBy(x => x.ItemId)
                .Select(o =>
                new TalkQuestion
                {
                    FestivalEvent = o.Item,
                    Question = o.Opmerking
                })
                .ToList();

            return questions;
        }

        public Location GetLocation(int id)
        {
            Location location = db.Locations.Find(id);

            return location;
        }

        //Get all events with sales data
        public List<SalesItem> GetAllEvents()
        {
            List<SalesItem> salesList = db.OrderItems
                .Include(x => x.Item)
                .GroupBy(x => x.Item.ID)
                .Select(o =>
                new SalesItem
                {
                    Id = o.FirstOrDefault().Item.ID,
                    CartTitle = o.FirstOrDefault().Item.CartTitle,
                    CartDescription = o.FirstOrDefault().Item.CartDescription,
                    StartDate = o.FirstOrDefault().Item.StartDate,
                    TicketPrice = o.FirstOrDefault().Item.TicketPrice,
                    Revenue = o.Sum(t => t.Prijs * t.Aantal),
                    Seats = o.FirstOrDefault().Item.Seats,
                    FreeSeats = o.FirstOrDefault().Item.Seats - o.Sum(t => t.Aantal),
                    SeatsSold = o.Sum(t => t.Aantal)
                })
                .OrderBy(i => i.StartDate)
                .ToList();

            return salesList;
        }

        //Get all events with sales on given day
        public List<SalesItem> GetAllEvents(DateTime dateTime)
        {
            List<SalesItem> salesList = db.OrderItems
                .Include(x => x.Item)
                .Include(x => x.Order)
                .Where(x => DbFunctions.TruncateTime(x.Order.OrderPayed) == dateTime.Date)
                .GroupBy(x => x.Item.ID)
                .Select(o =>
                new SalesItem
                {
                    Id = o.FirstOrDefault().Item.ID,
                    CartTitle = o.FirstOrDefault().Item.CartTitle,
                    CartDescription = o.FirstOrDefault().Item.CartDescription,
                    StartDate = o.FirstOrDefault().Item.StartDate,
                    TicketPrice = o.FirstOrDefault().Item.TicketPrice,
                    Revenue = o.Sum(t => t.Prijs * t.Aantal),
                    Seats = o.FirstOrDefault().Item.Seats,
                    FreeSeats = o.FirstOrDefault().Item.Seats - o.Sum(t => t.Aantal),
                    SeatsSold = o.Sum(t => t.Aantal)
                })
                .OrderBy(i => i.StartDate)
                .ToList();

            return salesList;
        }

        public int GetTotalSales()
        {
            int total = db.OrderItems
                .GroupBy(i => 1)
                .Select(o => o.Sum(t => t.Aantal))
                .SingleOrDefault();

            return total;
        }

        public double GetTotalRevenue()
        {
            int total = db.OrderItems
                .GroupBy(i => 1)
                .Select(o => o.Sum(t => (t.Prijs * t.Aantal)))
                .SingleOrDefault();

            return total;
        }

		public void Dispose()
		{
			db.Dispose();
		}
    }
}