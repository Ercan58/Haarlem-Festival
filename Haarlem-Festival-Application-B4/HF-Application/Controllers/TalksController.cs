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
      

        // GET: Talks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talk talk = (Talk)db.FestivalEvent.Find(id);
            if (talk == null)
            {
                return HttpNotFound();
            }
            return View(talk);
        }

        // GET: Talks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CartDescription,CartTitle,TicketType,TicketPrice,EndDate,StartDate,Interview,ReservationInfo,ImagePath")] Talk talk)
        {
            if (ModelState.IsValid)
            {
                db.FestivalEvent.Add(talk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talk);
        }

        // GET: Talks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talk talk = (Talk)db.FestivalEvent.Find(id);
            if (talk == null)
            {
                return HttpNotFound();
            }
            return View(talk);
        }

        // POST: Talks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CartDescription,CartTitle,TicketType,TicketPrice,EndDate,StartDate,Interview,ReservationInfo,ImagePath")] Talk talk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talk);
        }

        // GET: Talks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talk talk = (Talk)db.FestivalEvent.Find(id);
            if (talk == null)
            {
                return HttpNotFound();
            }
            return View(talk);
        }

        // POST: Talks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talk talk = (Talk)db.FestivalEvent.Find(id);
            db.FestivalEvent.Remove(talk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
