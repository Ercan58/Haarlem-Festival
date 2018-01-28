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
using HF_Application.Interface;
using HF_Application.Repositories;

namespace HF_Application.Controllers
{
    public class TalksController : Controller
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();
        private ITalkRepository talkRepository = new TalkRepository();
        private IEventRepository eventRepository = new EventRepository();

        private List<Talk> AllTalkEvents;
       

        public TalksController()
        {
            AllTalkEvents = new List<Talk>();
            this.AllTalkEvents = talkRepository.GetAllTalkEvents();
        }

        // GET: Talks
        public ActionResult Index(DateTime? startDate)
        {

            TalksModel talksModel = new TalksModel();
            if (startDate == null)
            {
                talksModel.AllTalkEvents = AllTalkEvents;
                talksModel.SalesList = eventRepository.GetAllEvents();
            }
            else
            {
                DateTime selectieStartDate = startDate.GetValueOrDefault();
                talksModel.AllTalkEvents = talkRepository.GetTalkEvents(selectieStartDate);
                talksModel.SalesList = eventRepository.GetAllEvents();

            }
            return View(talksModel);
        }


        public ActionResult Talk1(int id)
        {
            TalksModel talksModel = new TalksModel();


            talksModel.CurrentTalk = talkRepository.GetCurrentTalkEvent(id);

            talksModel.JazzCross = talkRepository.GetCrossJazzEvents();
            talksModel.RestaurantsCross = talkRepository.GetCrossDinerEvents();



            return View(talksModel);
        }

    }
}
