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
		    return View();
	    }

	    public ActionResult Hear()
	    {
            var events = eventRepository.GetAllHearEvents();

            return View(events);
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