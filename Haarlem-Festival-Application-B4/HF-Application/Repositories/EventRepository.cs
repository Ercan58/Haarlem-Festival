using System;
using System.Collections.Generic;
using System.Linq;
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

        public Diner GetTasteEvent(int? id)
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

        public void UpdateTalkEvent(Talk festivalEvent)
        {
            db.Entry(festivalEvent).State = EntityState.Modified;
            db.SaveChanges();
        }
        
        //implementeren als er een db tabel is aangemaakt

        //public List<TalkQuestion> GetAllTalkQuestions() {
        //    List<TalkQuestion> questions = new List<TalkQuestion>();
        //    foreach (var item in db.TalkQuestions)
        //    {
        //        questions.Add(item);
        //    }

        //    return questions;
        //}

        public List<Photo> GetAllPhotos(string directory)
        {
            List<Photo> imageList = new List<Photo>();
            foreach (var item in Directory.GetFiles(directory).Select(path => Path.GetFileName(path)))
            {
                Photo photo = new Photo(item, "~/Content/images/events/" + item);
                imageList.Add(photo);
            }

            return imageList;
        }

        public Photo GetPhoto(string fileName)
        {
            Photo photo = new Photo(fileName, "~/Content/images/events/" + fileName);

            return photo;
        }
    }
}