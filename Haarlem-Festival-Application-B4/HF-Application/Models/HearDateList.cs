using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class HearDateList
    {
        public string Date { get; set; }
        public List<Events.Jazz> EventList { get; set; }

        public HearDateList(string date, List<Events.Jazz> eventList)
        {
            Date = date;
            EventList = eventList;
        }
    }
}