using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using HF_Application.Models.Events;
using HF_Application.Models.ViewModel;
using HF_Application.Repositories;
using HF_Application.Interface;

namespace HF_Application.Controllers
{
	public class HomeController : Controller
	{

        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        public HomeController()
        {
        }
		public ActionResult Index()
		{
            HomeViewModel home = new HomeViewModel();
            home.jazzEvents = db.Jazzs.OrderBy(j => Guid.NewGuid()).Take(4).ToList();
            home.restoList = db.Diners.OrderBy(s => Guid.NewGuid()).Take(4).ToList();
            home.talkList = db.Talks.OrderBy(t => Guid.NewGuid()).Take(3).ToList();


            return View(home);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}