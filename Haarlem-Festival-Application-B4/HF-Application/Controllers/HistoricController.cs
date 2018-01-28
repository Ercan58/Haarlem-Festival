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
        private List<Historic> AllHistoricEvents;



        public HistoricController()
        {
            AllHistoricEvents = new List<Historic>();
            this.AllHistoricEvents = historyRepository.GetAllHistoryEvents();

        }


        // GET: Jazzs
        public ActionResult Index(string date)
        {

            HistoricModel HistModel = new HistoricModel();

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


    }
}