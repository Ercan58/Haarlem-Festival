using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models.Events;

namespace HF_Application.Models.ViewModel
{
    public class HistoricDetails
    {
        public Historic HistoicEvent { get; set; }
        public List<Restaurant> CrossSellingRestaurauntList { get; set; }
        public List<Talk> CrossSellingTalk { get; set; }
    }
}