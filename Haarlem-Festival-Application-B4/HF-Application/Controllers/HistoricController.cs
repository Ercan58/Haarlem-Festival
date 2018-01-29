using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using HF_Application.Models.Events;
using HF_Application.Models.ViewModel;
using HF_Application.Interface;
using HF_Application.Repositories;

namespace HF_Application.Controllers
{
    public class HistoricController : Controller
    {

        private IHistoricRepository historyRepository = new HistoricRepository();
        private HaarlemFestivalContext db = new HaarlemFestivalContext();
        private List<Historic> AllHistoricEvents;



        public HistoricController()
        {
            AllHistoricEvents = new List<Historic>();
            this.AllHistoricEvents = historyRepository.GetAllHistoryEvents();

        }


        // GET: HISTORC
        public ActionResult Index(string date)
        {

            Models.ViewModel.HistoricModel HistModel = new Models.ViewModel.HistoricModel();

            if (date == null)
            {
               HistModel.AllHistoricEvents  = historyRepository.GetAllHistoryEvents();

            }
            else
            {
                DateTime datetime = Convert.ToDateTime(date);
                HistModel.AllHistoricEvents = historyRepository.GetHistoricEvents(datetime);

            }
            return View(HistModel);

        }


        public ActionResult Details(int id)
        {
            HistoricDetails hisEventDetail = new HistoricDetails();
            hisEventDetail.HistoicEvent = historyRepository.GetJazzEventById(id);
            hisEventDetail.CrossSellingRestaurauntList = db.Restaurants.OrderBy(j => Guid.NewGuid()).Take(2).ToList();
            hisEventDetail.CrossSellingTalk = db.Talks.OrderBy(j => Guid.NewGuid()).Take(2).ToList();


            return View(hisEventDetail);
        }




    }
}