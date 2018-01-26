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
using HF_Application.Interface;



namespace HF_Application.Controllers
{
    public class HearController : Controller
    {
        private IJazzRepository IJazzRepository = new JazzRepository();
        private IDinerRepository IDinerRepository = new DinerRepository();
        private List<Jazz> AllJazzEvents;



        public HearController()
        {
            AllJazzEvents = new List<Jazz>();
            this.AllJazzEvents = IJazzRepository.GetAllJazzEvents();

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
            JazzDetail JazzEventDetail = new JazzDetail();
            JazzEventDetail.JazzEvent = IJazzRepository.GetJazzEventById(id);
            JazzEventDetail.CrossSellingRestaurauntList = IJazzRepository.CrossSellingRestaurauntList();


            return View(JazzEventDetail);
        }
    }
}
