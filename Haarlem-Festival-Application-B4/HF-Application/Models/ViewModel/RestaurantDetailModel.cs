using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models;
using HF_Application.Models.Events;

namespace HF_Application.Models.ViewModel
{
    public class RestaurantDetailModel
    {
        public Restaurant restaurant { get; set; }
        public List<Diner> DinerEvents { get; set; }
        public List<FestivalEvent> SuggestionEvents { get; set; }

    }
}