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
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"].ToString();
            }

            var events = eventRepository.GetAllTasteEvents();

            return View(events);
        }

        public ActionResult AddTaste()
        {
            ViewBag.Locations = eventRepository.GetTasteLocations();
            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTaste(Models.Events.DinerModel model)
        {
            if (ModelState.IsValid)
            {
                Models.Events.Diner festivalEvent = new Models.Events.Diner
                {
                    CartDescription = model.CartDescription,
                    CartTitle = model.CartTitle,
                    TicketPrice = model.TicketPrice,
                    ReducedPrice = model.ReducedPrice,
                    RestaurantId = model.RestaurantId,
                    Restaurant = eventRepository.GetRestaurant(model.RestaurantId),
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Seats = model.Seats
                };
                eventRepository.AddTasteEvent(festivalEvent);

                ViewBag.Locations = eventRepository.GetTasteLocations();
                return RedirectToAction("Taste");
            }

            //return if invalid entry
            return View(model);
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
            if (ModelState.IsValid)
            {
                festivalEvent.Restaurant = eventRepository.GetRestaurant(festivalEvent.RestaurantId);
                eventRepository.UpdateTasteEvent(festivalEvent);
                TempData["message"] = String
                    .Format("'{0}' on '{1}' has been saved successfully",
                    festivalEvent.CartTitle,
                    festivalEvent.StartDate
                    .ToShortDateString());
                return RedirectToAction("Taste");
            }

            ViewBag.Locations = eventRepository.GetTasteLocations();
            return View(festivalEvent);
        }

        public ActionResult Hear()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"].ToString();
            }

            var events = eventRepository.GetAllHearEvents();

            return View(events);
        }

        public ActionResult AddHear()
        {
            ViewBag.Locations = eventRepository.GetHearLocations();
            return View();
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
            if (ModelState.IsValid)
            {
                festivalEvent.Location = eventRepository.GetLocation(festivalEvent.Location.Id);
                eventRepository.UpdateHearEvent(festivalEvent);
                TempData["message"] = String
                    .Format("'{0}' on '{1}' has been saved successfully",
                    festivalEvent.CartTitle,
                    festivalEvent.StartDate
                    .ToShortDateString());
                return RedirectToAction("Hear");
            }

            ViewBag.Locations = eventRepository.GetHearLocations();
            return View(festivalEvent);
        }

        public ActionResult See()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"].ToString();
            }

            var events = eventRepository.GetAllSeeEvents();

            return View(events);
        }

        public ActionResult AddSee()
        {
            ViewBag.Locations = eventRepository.GetSeeLocations();
            return View();
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
            if (ModelState.IsValid)
            {
                eventRepository.UpdateSeeEvent(festivalEvent);
                TempData["message"] = String
                    .Format("'{0}' on '{1}' has been saved successfully",
                    festivalEvent.CartTitle,
                    festivalEvent.StartDate
                    .ToShortDateString());
                return RedirectToAction("See");
            }

            ViewBag.Locations = eventRepository.GetSeeLocations();
            return View(festivalEvent);
        }
        public ActionResult Talk()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"].ToString();
            }

            var events = eventRepository.GetAllTalkEvents();

            return View(events);
        }

        public ActionResult AddTalk()
        {
            ViewBag.Locations = eventRepository.GetTalkLocations();
            return View();
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
            if (ModelState.IsValid)
            {
                eventRepository.UpdateTalkEvent(festivalEvent);
                TempData["message"] = String
                    .Format("'{0}' on '{1}' has been saved successfully",
                    festivalEvent.CartTitle,
                    festivalEvent.StartDate
                    .ToShortDateString());
                return RedirectToAction("Talk");
            }

            ViewBag.Locations = eventRepository.GetTalkLocations();
            return View(festivalEvent);
        }

        public ActionResult AttendeeQuestions()
        {
            List<TalkQuestion> questionList = eventRepository.GetAllTalkQuestions();

            return View(questionList);
        }

        public ActionResult Sales()
        {
            List<SalesItem> salesList = eventRepository.GetAllEvents();
            ViewBag.TotalSold = eventRepository.GetTotalSales();
            ViewBag.TotalRevenue = eventRepository.GetTotalRevenue();

            return View(salesList);
        }

        public ActionResult DaySales()
        {
            List<SalesItem> salesList = eventRepository.GetAllEvents();

            return View(salesList);
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                eventRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}