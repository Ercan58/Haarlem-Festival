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

        // TODO: Repository aanmaken 
            
        private ITalkRepository talkRepository = new TalkRepository();
        private IEventRepository eventRepository = new EventRepository();

        private List<Talk> AllTalkEvents;
       
        public TalksController()
        {
            AllTalkEvents = new List<Talk>();
            this.AllTalkEvents = talkRepository.GetAllTalkEvents();
        }

        // GET: Talks
        public ActionResult Index()
        {
            //TODO: Action1: Index get all events 
            TalksModel talksModel = new TalksModel();

            //TODO: Talksmodel = get talk events methode van Reposit
            talksModel.AllTalkEvents = talkRepository.GetAllTalkEvents();

            //TODO: Left seats van Daniel halen en mijn view gebruiken
            talksModel.SalesList = eventRepository.GetAllEvents();

            //TODO: returm view with model
            return View(talksModel);
        }

        //todo: 
        public ActionResult Talk1(int id)
        {
            //todo: Action2 To Detail pagina met eventid als in parameter 
            TalksModel talksModel = new TalksModel();

            //todo: Controller get current event 
            talksModel.CurrentTalk = talkRepository.GetCurrentTalkEvent(id);

            //todo Controller cross selling get 2 events voor jazz en diner 
            talksModel.JazzCross = talkRepository.GetCrossJazzEvents();
            talksModel.RestaurantsCross = talkRepository.GetCrossDinerEvents();


            //todo:Controller return view met model 
            return View(talksModel);
        }

    }
}
