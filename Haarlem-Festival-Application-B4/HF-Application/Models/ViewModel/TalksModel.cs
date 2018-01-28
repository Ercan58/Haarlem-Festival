using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models;
using HF_Application.Models.Events;

namespace HF_Application.Models.ViewModel
{
    public class TalksModel
    {
        // voor Talk pagina 
        public List<Talk> AllTalkEvents { get; set; }
        // Talk pagina voor left seats
        public List<SalesItem> SalesList { get; set; }

        // detail pagina 1 event 
        public Talk CurrentTalk { get; set; }

        // cross selling andere events
        public List<Jazz> JazzCross { get; set; }
        public List<Restaurant> RestaurantsCross { get; set; }

       


    }
}