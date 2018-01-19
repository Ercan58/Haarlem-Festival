using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;

namespace HF_Application.Controllers
{
    public class UserController : Controller
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();
        // GET: User
        public ActionResult Index()
        {
            using (HaarlemFestivalContext db = new HaarlemFestivalContext())
            {
                return View(db.Users.ToList());
            }
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            if(ModelState.IsValid)
            {
                using (HaarlemFestivalContext db = new HaarlemFestivalContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Massage = user.Email + " " + "Successfully registerd.";
            }
            return View();
        }

        //login 
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(User user)
        {
            using (HaarlemFestivalContext db = new HaarlemFestivalContext())
            {
                var usr = db.Users.Single(u => u.Mail == user.Mail && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserId"] = usr.Id.ToString();
                    Session["Name"] = usr.Email.ToString();
                    return RedirectToAction("LoggedIn");
          
                }
                else
                {
                    ModelState.AddModelError(" ", "UserName or Pssword is wrong");
                }


            }

            return View();
        }


        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }

      
    }
}