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

        public List<Talk> GetAllTalkEvents()
        {
            List<Talk> TalkEvents = new List<Talk>();
            return TalkEvents = db.Talks.Include(a => a.Location).ToList();
        }

        public List<Talk> GetCrossTalkEvents(int id)
        {
            List<Talk> talkEvent = new List<Talk>();
            var selectionById = db.Talks.Where(d => d.ID != id).Include(l => l.Location).ToList();
            foreach (Talk TalkEvent in selectionById)
            {
                talkEvent.Add(TalkEvent);
            }
            return talkEvent;
        }

        public Talk GetCurrentTalkEvent(int id)
        {
            Talk talkEvent = db.Talks.Where(a => a.ID == id).Include(n => n.Location).SingleOrDefault();

            return talkEvent;
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

    }
}