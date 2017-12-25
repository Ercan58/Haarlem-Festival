using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models;

namespace HF_Application.Models.ViewModel
{
    public class RestaurantDetailModel
    {
        public Restaurant restaurant { get; set; }
        public List<FestivalEvent> SuggestionEvents { get; set; }

    }
}