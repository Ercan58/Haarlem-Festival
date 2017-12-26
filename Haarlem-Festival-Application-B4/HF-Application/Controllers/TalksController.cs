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

namespace HF_Application.Controllers
{
    public class TalksController : Controller
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        private List<Talk> AllTalkEvents;

        public TalksController()
        {
            AllTalkEvents = new List<Talk>();
            this.AllTalkEvents = GetAllTalkEvents();
        }
        public List<Talk> GetAllTalkEvents()
        {
            List<Talk> TalkEvents = new List<Talk>();
            return TalkEvents = db.Talks.Include(a => a.Location).ToList();
        }

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



        // GET: Talks
        public ActionResult Index(DateTime? startDate)
        {

            TalksModel talksModel = new TalksModel();
            if (startDate == null)
            {
                talksModel.AllTalkEvents = AllTalkEvents;
            }
            else
            {
                DateTime selectieStartDate = startDate.GetValueOrDefault();
                talksModel.AllTalkEvents = GetTalkEvents(selectieStartDate);

            }
            return View(talksModel);
        }

        public ActionResult Talk1 (int id)
        {
            TalksModel talksModel = new TalksModel();
        
                
            talksModel.AllTalkEvents = GetCurrentTalkEvent(id);
            talksModel.CrossTalkEvents = GetCrossEvents(id);
            talksModel.RestaurantsCross = GetRestaurants();

            return View(talksModel);
        }


        public List<Talk> GetCurrentTalkEvent(int id)
        {
            List<Talk> talkEvent = new List<Talk>();
            var selectionById = db.Talks.Where(d => d.ID == id).Include(l => l.Location).ToList();
            foreach (Talk TalkEvent in selectionById)
            {
                talkEvent.Add(TalkEvent);
            }
            return talkEvent;
        }

        public List<Talk> GetCrossEvents(int id)
        {
            List<Talk> talkEvent = new List<Talk>();
            var selectionById = db.Talks.Where(d => d.ID != id).Include(l => l.Location).ToList();
            foreach (Talk TalkEvent in selectionById)
            {
                talkEvent.Add(TalkEvent);
            }
            return talkEvent;
        }

       public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> talkEvent = new List<Restaurant>();
            var selectionById = db.Restaurants.Include(a => a.FoodTypes).Include(b => b.Location).ToList();
            foreach (Restaurant TalkEvent_Rest in selectionById)
            {
                talkEvent.Add(TalkEvent_Rest);
            }
            return talkEvent;
        }


    }
}
