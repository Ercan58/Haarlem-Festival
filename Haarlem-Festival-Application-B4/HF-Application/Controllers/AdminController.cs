using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace HF_Application.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        private IEventRepository eventRepository = new EventRepository();

        public ActionResult Index()
        {
            return View();
        }

        // List of Taste events
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

        // Post new Taste event
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

                return RedirectToAction("Taste");
            }

            //return if invalid entry
            ViewBag.Locations = eventRepository.GetTasteLocations();
            return View(model);
        }

        // Get Taste event
        public ActionResult EditTaste(int? id)
        {
            var festivalEvent = eventRepository.GetTasteEvent(id);
            if (festivalEvent == null)
                return HttpNotFound();
            ViewBag.Locations = eventRepository.GetTasteLocations();

            return View(festivalEvent);
        }

        // Post Taste event
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


        // List of Hear events
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

        // Post new Hear event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHear(Models.Events.JazzModel model)
        {
            if (ModelState.IsValid)
            {
                Models.Events.Jazz festivalEvent = new Models.Events.Jazz
                {
                    CartDescription = model.CartDescription,
                    CartTitle = model.CartTitle,
                    Band = model.Band,
                    imagePath = model.imagePath,
                    TicketPrice = model.TicketPrice,
                    Location = eventRepository.GetLocation(model.Location.Id),
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Seats = model.Seats
                };
                eventRepository.AddHearEvent(festivalEvent);

                return RedirectToAction("Hear");
            }

            //return if invalid entry
            ViewBag.Locations = eventRepository.GetHearLocations();
            return View(model);
        }

        // Get Hear event
        public ActionResult EditHear(int? id)
        {
            var festivalEvent = eventRepository.GetHearEvent(id);
            if (festivalEvent == null)
                return HttpNotFound();
            ViewBag.Locations = eventRepository.GetHearLocations();

            return View(festivalEvent);
        }

        // Post Hear event
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

        // List of See events
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

        // Post new See event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSee(Models.Events.HistoricModel model)
        {
            if (ModelState.IsValid)
            {
                Models.Events.Historic festivalEvent = new Models.Events.Historic
                {
                    CartDescription = model.CartDescription,
                    CartTitle = model.CartTitle,
                    TicketPrice = model.TicketPrice,
                    FamilyPrice = (int)model.FamilyPrice, // tijdelijke fix, model heeft int ipv double....
                    tourGuid = model.TourGuide,
                    Location = eventRepository.GetLocation(model.Location.Id),
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Seats = model.Seats
                };
                eventRepository.AddSeeEvent(festivalEvent);

                return RedirectToAction("See");
            }

            //return if invalid entry
            ViewBag.Locations = eventRepository.GetSeeLocations();
            return View(model);
        }

        // Get See event
        public ActionResult EditSee(int? id)
        {
            var festivalEvent = eventRepository.GetSeeEvent(id);
            if (festivalEvent == null)
                return HttpNotFound();
            ViewBag.Locations = eventRepository.GetSeeLocations();

            return View(festivalEvent);
        }

        // Post See event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSee(Models.Events.Historic festivalEvent)
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

        // List of Talk events
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

        // Post new Talk event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTalk(Models.Events.TalkModel model)
        {
            if (ModelState.IsValid)
            {
                Models.Events.Talk festivalEvent = new Models.Events.Talk
                {
                    CartDescription = model.CartDescription,
                    Interview = model.Interview,
                    CartTitle = model.CartTitle,
                    TicketPrice = model.TicketPrice,
                    Location = eventRepository.GetLocation(model.Location.Id),
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Seats = model.Seats,
                    ImagePath = model.ImagePath
                };
                eventRepository.AddTalkEvent(festivalEvent);

                return RedirectToAction("Talk");
            }

            //return if invalid entry
            ViewBag.Locations = eventRepository.GetTalkLocations();
            return View(model);
        }

        // Get Talk event
        public ActionResult EditTalk(int? id)
        {
            var festivalEvent = eventRepository.GetTalkEvent(id);
            if (festivalEvent == null)
                return HttpNotFound();
            ViewBag.Locations = eventRepository.GetTalkLocations();

            return View(festivalEvent);
        }

        // Post Talk event
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

        // List of attendee questions
        public ActionResult AttendeeQuestions()
        {
            List<TalkQuestion> questionList = eventRepository.GetAllTalkQuestions();

            return View(questionList);
        }

        // Total sales page
        public ActionResult Sales()
        {
            List<SalesItem> salesList = eventRepository.GetAllEvents();
            ViewBag.TotalSold = eventRepository.GetTotalSales();
            ViewBag.TotalRevenue = eventRepository.GetTotalRevenue();

            return View(salesList);
        }

        // Sales per day page
        public ActionResult DaySales()
        {
            DateTime dateTime = DateTime.Now; // default date is today
            List<SalesItem> salesList = eventRepository.GetAllEvents(dateTime);
            ViewBag.DateTime = dateTime;
            return View(salesList);
        }

        // Sales per given day
        [HttpPost]
        public ActionResult DaySales(DateTime dateTime)
        {
            List<SalesItem> salesList = eventRepository.GetAllEvents(dateTime);
            ViewBag.DateTime = dateTime;
            return View(salesList);
        }

        // Export total sales to Excel sheet
        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = eventRepository.GetAllEvents();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Haarlem-Festival-Sales.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("Sales");
        }

        // Export sales for given day to Excel sheet
        public ActionResult ExportToExcelByDate(DateTime dateTime)
        {
            var gv = new GridView();
            gv.DataSource = eventRepository.GetAllEvents(dateTime);
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Haarlem-Festival-Sales-Day.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("DaySales", dateTime);
        }

        // Photo manager
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

        // Post new photo
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

        // Delete photo
        public ActionResult DeletePhoto(string fileName)
        {
            if (fileName == null)
                return HttpNotFound();

            Photo photo = new Photo(fileName, "~/Content/images/events/" + fileName);
            return View(photo);
        }

        // Delete photo confirmation
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