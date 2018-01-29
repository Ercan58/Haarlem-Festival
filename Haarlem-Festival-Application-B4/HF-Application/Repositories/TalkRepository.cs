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

        //Todo: Repository alle events halen methode 
        public List<Talk> GetAllTalkEvents()
        {
            //TODO: list Talk en LinQ query
            List<Talk> TalkEvents = new List<Talk>();
            return TalkEvents = db.Talks.Include(a => a.Location).ToList();
        }

        //TODO: Current Talk event Voor detail pagina
        public Talk GetCurrentTalkEvent(int id)
        {
            Talk talkEvent = db.Talks.Where(a => a.ID == id).Include(n => n.Location).SingleOrDefault();

            return talkEvent;
        }

        // Get 2 Diner events voor Cross selling voor cross selling
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