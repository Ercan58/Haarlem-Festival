using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using HF_Application.Models.ViewModel;

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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (HaarlemFestivalContext db = new HaarlemFestivalContext())
            {
                  User usr = db.Users.Single(u => u.Mail == user.Mail && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserId"] = usr.Id.ToString();
                    Session["Name"] = usr.Email.ToString();
                    return RedirectToAction("LoggedIn", usr);
          
                }
                else
                {
                    ModelState.AddModelError(" ", "UserName or Pssword is wrong");
                }


            }

            return View();
        }


        public ActionResult LoggedIn(User user)
        {
            if(user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        //public ActionResult Orders()
        //{
        //    List<Order> ordersmodel = new List<Order>();
        //    List<Order> ordersmodel1 = new List<Order>();

        //    ordersmodel = db.Orders.ToList();

        //    foreach (Order item in ordersmodel)
        //    {
        //        ordersmodel1.Add(item);
        //    }
         
        //    return View(ordersmodel);
        //}

      
    }
}