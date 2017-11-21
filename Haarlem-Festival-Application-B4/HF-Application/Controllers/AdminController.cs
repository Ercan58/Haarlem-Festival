using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HF_Application.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
		{
			Console.WriteLine("Hoi Daniel!"); 
			return View();
        }
    }
}