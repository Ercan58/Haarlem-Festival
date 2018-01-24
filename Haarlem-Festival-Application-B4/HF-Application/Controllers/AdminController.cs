using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult EditTaste(int? id)
        {
            var festivalEvent = eventRepository.GetTasteEvent(id);
            if (festivalEvent == null)
                return HttpNotFound();
            ViewBag.Locations = eventRepository.GetTasteLocations();

            return View(festivalEvent);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTaste(Models.Events.Diner festivalEvent)
        {
            ViewBag.Locations = eventRepository.GetTasteLocations();

            if (ModelState.IsValid)
            {
                eventRepository.UpdateTasteEvent(festivalEvent);
                return RedirectToAction("Index");
            }

            return View(festivalEvent);
        }

        public ActionResult Hear()
        {
            var events = eventRepository.GetAllHearEvents();

            return View(events);
        }

        // Get
        public ActionResult EditHear(int? id)
        {
            var festivalEvent = eventRepository.GetHearEvent(id);
            if (festivalEvent == null)
                return HttpNotFound();
            ViewBag.Locations = eventRepository.GetHearLocations();

            return View(festivalEvent);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHear(Models.Events.Jazz festivalEvent)
        {
            ViewBag.Locations = eventRepository.GetHearLocations();

            if (ModelState.IsValid)
            {
                eventRepository.UpdateHearEvent(festivalEvent);
                return RedirectToAction("Index");
            }

            return View(festivalEvent);
        }

        public ActionResult See()
        {
            var events = eventRepository.GetAllSeeEvents();

            return View(events);
        }

        // Get
        public ActionResult EditSee(int? id)
        {
            var festivalEvent = eventRepository.GetSeeEvent(id);
            if (festivalEvent == null)
                return HttpNotFound();
            ViewBag.Locations = eventRepository.GetSeeLocations();

            return View(festivalEvent);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult See(Models.Events.Historic festivalEvent)
        {
            ViewBag.Locations = eventRepository.GetSeeLocations();

            if (ModelState.IsValid)
            {
                eventRepository.UpdateSeeEvent(festivalEvent);
                return RedirectToAction("Index");
            }

            return View(festivalEvent);
        }
        public ActionResult Talk()
        {
            var events = eventRepository.GetAllTalkEvents();

            return View(events);
        }

        // Get
        public ActionResult EditTalk(int? id)
        {
            var festivalEvent = eventRepository.GetTalkEvent(id);
            if (festivalEvent == null)
                return HttpNotFound();
            ViewBag.Locations = eventRepository.GetTalkLocations();

            return View(festivalEvent);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTalk(Models.Events.Talk festivalEvent)
        {
            ViewBag.Locations = eventRepository.GetTalkLocations();

            if (ModelState.IsValid)
            {
                eventRepository.UpdateTalkEvent(festivalEvent);
                return RedirectToAction("Index");
            }

            return View(festivalEvent);
        }

        public ActionResult Photos()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"].ToString();
            }

            string directory = Server.MapPath("~/Content/images/events/");

            List<Photo> imageList = new List<Photo>();
            foreach (var item in Directory.GetFiles(directory).Select(path => Path.GetFileName(path)))
            {
                Photo photo = new Photo(item, "~/Content/images/events/" + item);
                imageList.Add(photo);
            }

            return View(imageList);
        }

        public ActionResult AddPhoto()
        {
            return View();
        }

        // Post
        [HttpPost]
        public ActionResult AddPhoto(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/images/events/"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    TempData["message"] = String.Format("Photo '{0}' uploaded successfully", file.FileName);
                    return RedirectToAction("Photos");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file";
            }
            return View();
        }

        public ActionResult DeletePhoto(string fileName)
        {
            if (fileName == null)
                return HttpNotFound();

            Photo photo = new Photo(fileName, "~/Content/images/events/" + fileName);
            return View(photo);
        }

        // Post
        [HttpPost, ActionName("DeletePhoto")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePhotoConfirmed(string fileName)
        {
            try
            {
                System.IO.File.Delete(Server.MapPath("~/Content/images/events/") + fileName);
                TempData["message"] = String.Format("Photo '{0}' deleted successfully", fileName);
                return RedirectToAction("Photos");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
            }
            return View(fileName);
        }
    }
}