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
    public class HearController : Controller
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();
        private List<Jazz> AllJazzEvents;

        public HearController()
        {
            AllJazzEvents = new List<Jazz>();

            this.AllJazzEvents = GetAllJazzEvents();
        }

        public List<Jazz> GetAllJazzEvents()
        {
            List<Jazz> JazzEvents = new List<Jazz>();
            return JazzEvents = db.Jazzs.Include(a=>a.Location).ToList();
        }

        public List<Jazz> GetJazzEvents(DateTime eventDate)
        {
            List<Jazz> jazzEvents = new List<Jazz>();

            var selectionByStartDate = db.Jazzs.Where(d => DbFunctions.TruncateTime(d.StartDate) == eventDate).Include(l=>l.Location).ToList();
            foreach (Jazz jazzEvent in selectionByStartDate)
            {
                jazzEvents.Add(jazzEvent);
            }
            return jazzEvents;

        }
        // GET: Jazzs
        public ActionResult Index(DateTime? startDate)
        {
            JazzsModel jazzsModel = new JazzsModel();
            if (id == null)
            {
                jazzsModel.AllJazzEvents = AllJazzEvents;
            }
            else
            {
                DateTime selectieStartDate = startDate.GetValueOrDefault();
                jazzsModel.AllJazzEvents = GetJazzEvents(selectieStartDate);

            }
            return View(jazzsModel);

        }

        // GET: Jazzs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jazz jazz = (Jazz)db.FestivalEvent.Find(id);
            if (jazz == null)
            {
                return HttpNotFound();
            }
            return View(jazz);
        }

        // GET: Jazzs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jazzs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Location,CartDescription,CartTitle,Price,Seats,TicketType,EndDate,StartDate,Band,imagePath")] Jazz jazz)
        {
            if (ModelState.IsValid)
            {
                db.FestivalEvent.Add(jazz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jazz);
        }

        // GET: Jazzs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jazz jazz = (Jazz)db.FestivalEvent.Find(id);
            if (jazz == null)
            {
                return HttpNotFound();
            }
            return View(jazz);
        }

        // POST: Jazzs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Location,CartDescription,CartTitle,Price,Seats,TicketType,EndDate,StartDate,Band,imagePath")] Jazz jazz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jazz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jazz);
        }

        // GET: Jazzs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jazz jazz = (Jazz)db.FestivalEvent.Find(id);
            if (jazz == null)
            {
                return HttpNotFound();
            }
            return View(jazz);
        }

        // POST: Jazzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jazz jazz = (Jazz)db.FestivalEvent.Find(id);
            db.FestivalEvent.Remove(jazz);
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
