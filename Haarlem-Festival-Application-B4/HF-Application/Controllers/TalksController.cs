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

        private List<Talk> AllTalkEvents;

        ITalkRepository talkRepository = new TalkRepository();
        IDinerRepository dinerRepository = new DinerRepository();

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
            }
            else
            {
                DateTime selectieStartDate = startDate.GetValueOrDefault();
                talksModel.AllTalkEvents = talkRepository.GetTalkEvents(selectieStartDate);

            }
            return View(talksModel);
        }

        public ActionResult Talk1 (int id)
        {
            TalksModel talksModel = new TalksModel();
        
                
            talksModel.AllTalkEvents = talkRepository.GetCurrentTalkEvent(id);
            talksModel.CrossTalkEvents =talkRepository.GetCrossTalkEvents(id);
            talksModel.RestaurantsCross = dinerRepository.GetAllRestaurants();

            return View(talksModel);
        }

    }
}
