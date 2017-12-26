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
        //private List<string> DaySelectionFilter;

        public HearController()
        {

            this.AllJazzEvents = IJazzRepository.GetAllJazzEvents();
            //this.DaySelectionFilter = IJazzRepository.DaySelectionFilter();
        }


        // GET: Jazzs
        public ActionResult Index(string date)
        {
      
            JazzsModel jazzsModel = new JazzsModel();

            if (date == null)
            {
                jazzsModel.AllJazzEvents = IJazzRepository.GetAllJazzEvents();
                
            }
            else
            {
                DateTime datetime = Convert.ToDateTime(date);
                jazzsModel.AllJazzEvents = IJazzRepository.GetJazzEvents(datetime);     

            }
            return View(jazzsModel);

        }

        public ActionResult Details(int id)
        {
            Jazz JazzEvent = IJazzRepository.Details(id);
            return View(JazzEvent);
        }
    }
}
