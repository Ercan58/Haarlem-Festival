using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Interface;
using HF_Application.Controllers;
using HF_Application.Models;
using HF_Application.Models.Events;
using HF_Application.Models.ViewModel;
using System.Data;
using System.Data.Entity;


namespace HF_Application.Repositories
{
    public class TalkRepository : ITalkRepository
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        // alle events halen 
        public List<Talk> GetAllTalkEvents()
        {
            List<Talk> TalkEvents = new List<Talk>();
            return TalkEvents = db.Talks.Include(a => a.Location).ToList();
        }

        // alle events halen
        public List<Talk> GetTalkEvents(DateTime date)
        {
            List<Talk> talkEvents = new List<Talk>();

            var selectionByStartDate = db.Talks.Where(d => d.StartDate == date).Include(l => l.Location).ToList();
            foreach (Talk TalkEvent in selectionByStartDate)
            {
                talkEvents.Add(TalkEvent);
            }
            return talkEvents;
        }

        // Voor detail pagina
        public Talk GetCurrentTalkEvent(int id)
        {
            Talk talkEvent = db.Talks.Where(a => a.ID == id).Include(n => n.Location).SingleOrDefault();

            return talkEvent;
        }

        // voor cross selling 
        public List<Restaurant> GetCrossDinerEvents()
        {
            List<Restaurant> diners = new List<Restaurant>();
           var diners1 =  db.Restaurants.OrderBy(r => Guid.NewGuid()).Take(2).ToList();
            foreach (var item in diners1)
            {
                diners.Add(item);
            }
            return diners;
        }

        // voor cross selling 
        public List<Jazz> GetCrossJazzEvents()
        {
            List<Jazz> jazz = new List<Jazz>();
            var jazz1 = db.Jazzs.OrderBy(r => Guid.NewGuid()).Take(2).ToList();
            foreach (var item in jazz1)
            {
                jazz.Add(item);
            }
            return jazz;
        }

    }
}