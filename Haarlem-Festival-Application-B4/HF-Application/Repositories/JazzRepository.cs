using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using HF_Application.Models.Events;
using HF_Application.Models.ViewModel;

namespace HF_Application.Repositories
{
    public class JazzRepository : IJazzRepository
    {

        private HaarlemFestivalContext db = new HaarlemFestivalContext();
        public List<Jazz> GetAllJazzEvents()
        {
            List<Jazz> JazzEvents = new List<Jazz>();
            return JazzEvents = db.Jazzs.Include(a => a.Location).ToList();
        }

        public List<Jazz> GetJazzEvents(DateTime datetime)
        {
            List<Jazz> JazzEventByDate = new List<Jazz>();

                return JazzEventByDate = (db.Jazzs
                .Where(s=> s.StartDate.Year == datetime.Year && s.StartDate.Day==datetime.Day && s.StartDate.Month == datetime.Month)
                .Include(a=>a.Location)
                .ToList());

        }

        public Jazz GetJazzEventById(int id)
        {
            Jazz JazzEvent = db.Jazzs.Where(a => a.ID == id).Include(n => n.Location).SingleOrDefault();
            return JazzEvent;
        }

        public List<Restaurant> CrossSellingRestaurauntList()
        {
            List<Restaurant> allRest = db.Restaurants.ToList();

            Random rnd = new Random();
            List<Restaurant> CrossSellingList = new List<Restaurant>();

            for (int i = 0; i < 2; i++)
            {
                int random = rnd.Next(0, allRest.Count());

                if(CrossSellingList.Contains(allRest[random]))
                { i--; } else {CrossSellingList.Add(allRest[random]); }
                
            }

            return CrossSellingList;
        }

        public List<Talk> CrossSellingTalk()
        {
            List<Talk> allTalk = db.Talks.ToList();

            Random rnd = new Random();
            List<Talk> CrossSellingList = new List<Talk>();

            for (int i = 0; i < 2; i++)
            {
                int random = rnd.Next(0, allTalk.Count());

                if (CrossSellingList.Contains(allTalk[random]))
                { i--; }
                else { CrossSellingList.Add(allTalk[random]); }

            }

            return CrossSellingList;
        }

    }
}