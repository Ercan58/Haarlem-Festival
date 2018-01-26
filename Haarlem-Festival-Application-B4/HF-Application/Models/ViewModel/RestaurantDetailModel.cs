using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using HF_Application.Models.Events;

namespace HF_Application.Models.ViewModel
{
    public class RestaurantDetailModel
    {
        public int selectDinerId { get; set; }
        public int selectPersons { get; set; }
        public string comments { get; set; }
        public Restaurant restaurant { get; set; }
        public Diner diner { get; set; }
        public List<SelectListItem> DinerEvents { get; set; }
        public List<SelectListItem> NumberPersons { get; set; }
        public List<FestivalEvent> SuggestionEvents { get; set; }
        public List<Talk> CrossTalkEvents { get; set; }
        public List<Jazz> HearCrossEvents { get; set; }


    }
}