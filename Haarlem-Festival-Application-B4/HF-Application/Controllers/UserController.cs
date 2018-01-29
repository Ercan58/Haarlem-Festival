﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using HF_Application.Models.ViewModel;
using HF_Application.Interface;
using HF_Application.Controllers;
using HF_Application.Models.Events;
using System.Data;


namespace HF_Application.Controllers
{

    public class UserController : Controller
    {

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
                    if (user.Admin == true)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if(user.Admin == false)
                    {
                        Session["UserId"] = usr.Id.ToString();
                        Session["Name"] = usr.Email.ToString();
                        Session["User"] = user;
                        return RedirectToAction("LoggedIn", usr);
                    }
                
          
                }
                else
                {
                    return RedirectToAction("login", "User");
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

    }
}