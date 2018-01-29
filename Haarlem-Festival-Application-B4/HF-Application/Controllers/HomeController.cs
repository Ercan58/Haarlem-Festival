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
        private IHomeRepository rp = new HomeRepository();
        public HomeController()
        {
        }
		public ActionResult Index()
		{
            HomeViewModel home = new HomeViewModel();
            home.jazzEvents = rp.jazzList();
            home.restoList = rp.restoList();
            home.talkList = rp.talkList();


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