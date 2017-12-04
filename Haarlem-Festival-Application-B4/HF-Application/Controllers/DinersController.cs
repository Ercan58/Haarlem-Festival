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

namespace HF_Application.Controllers
{
    public class DinersController : Controller
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        // GET: Diners
        public ActionResult Index()
        {
            return View(db.Diners.ToList());
        }

        // GET: Diners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diner diner = (Diner)db.FestivalEvent.Find(id);
            if (diner == null)
            {
                return HttpNotFound();
            }
            return View(diner);
        }

        // GET: Diners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Location,CartDescription,CartTitle,Price,Seats,TicketType,EndDate,StartDate,Session,RestaurantName,imagePath,FoodType")] Diner diner)
        {
            if (ModelState.IsValid)
            {
                db.FestivalEvent.Add(diner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diner);
        }

        // GET: Diners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diner diner = (Diner)db.FestivalEvent.Find(id);
            if (diner == null)
            {
                return HttpNotFound();
            }
            return View(diner);
        }

        // POST: Diners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Location,CartDescription,CartTitle,Price,Seats,TicketType,EndDate,StartDate,Session,RestaurantName,imagePath,FoodType")] Diner diner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diner);
        }

        // GET: Diners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diner diner = (Diner)db.FestivalEvent.Find(id);
            if (diner == null)
            {
                return HttpNotFound();
            }
            return View(diner);
        }

        // POST: Diners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diner diner = (Diner)db.FestivalEvent.Find(id);
            db.FestivalEvent.Remove(diner);
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
