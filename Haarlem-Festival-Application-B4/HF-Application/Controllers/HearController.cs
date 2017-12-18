﻿using System;
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
using HF_Application.Repositories;



namespace HF_Application.Controllers
{
    public class HearController : Controller
    {
        private IJazzRepository IJazzRepository = new JazzRepository();
        private List<Jazz> AllJazzEvents;
        public HearController()
        {
            AllJazzEvents = new List<Jazz>();

            this.AllJazzEvents = IJazzRepository.GetAllJazzEvents();
        }

        // GET: Jazzs
        public ActionResult Index(int? startDate)
        {
            JazzsModel jazzsModel = new JazzsModel();

            if (startDate == null)
            {
                jazzsModel.AllJazzEvents = IJazzRepository.GetAllJazzEvents();
                
            }
            else
            {
                int selectStartDate = startDate.GetValueOrDefault();
                jazzsModel.AllJazzEvents = GetJazzEvents(selectStartDate);

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
