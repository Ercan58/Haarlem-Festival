using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using HF_Application.Models.Events;
using HF_Application.Models.ViewModel;
using HF_Application.Repositories;



namespace HF_Application.Controllers
{
    public class HearController : Controller
    {
        private IJazzRepository IJazzRepository = new JazzRepository();
        private List<Jazz> AllJazzEvents;
        private List<string> DaySelectionFilter;

        public HearController()
        {

            this.AllJazzEvents = IJazzRepository.GetAllJazzEvents();
            this.DaySelectionFilter = IJazzRepository.DaySelectionFilter();
        }


        // GET: Jazzs
        public ActionResult Index(int? startDate)
        {
            JazzsModel jazzsModel = new JazzsModel();

            if (startDate.Equals(null))
            {
                jazzsModel.AllJazzEvents = IJazzRepository.GetAllJazzEvents();
                
            }
            else
            {
                string selectStartDate = startDate.GetValueOrDefault().ToString();
                jazzsModel.AllJazzEvents = IJazzRepository.GetJazzEvents(selectStartDate);

            }
            return View(jazzsModel);

        }
    }
}
