using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HF_Application.Controllers
{
    public class AdminController : Controller
    {
        private HF_Application.Models.HaarlemFestivalContext db = new Models.HaarlemFestivalContext();

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
            var events = db.Events.ToList();

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