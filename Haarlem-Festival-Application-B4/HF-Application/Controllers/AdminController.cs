using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;

namespace HF_Application.Controllers
{
    public class AdminController : Controller
    {
        private IEventRepository eventRepository = new EventRepository();

        // GET: Admin
        public ActionResult Index()
		{
			return View();
        }

	    public ActionResult Taste()
	    {
            var events = eventRepository.GetAllTasteEvents();

            return View(events);
        }

        // Get
        public ActionResult EditTaste(int id)
        {
            var festivalEvent = eventRepository.GetTasteEvent(id);
            ViewBag.Locations = new SelectList(eventRepository.GetLocations(), "Id", "Address");

            return View(festivalEvent);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTaste(Models.Events.Diner festivalEvent)
        {
            eventRepository.UpdateTasteEvent(festivalEvent);

            return View(festivalEvent);
        }

        public ActionResult Hear()
	    {
            var events = eventRepository.GetAllHearEvents();

            return View(events);
	    }

        // Get
        public ActionResult EditHear(int id)
        {
            var festivalEvent = eventRepository.GetHearEvent(id);

            return View(festivalEvent);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHear(Models.Events.Jazz festivalEvent)
        {
            eventRepository.UpdateHearEvent(festivalEvent);

            return View(festivalEvent);
        }

        public ActionResult See()
	    {
		    return View();
	    }

	    public ActionResult Talk()
	    {
		    return View();
	    }
    }
}