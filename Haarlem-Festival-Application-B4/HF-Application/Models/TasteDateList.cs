using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class TasteDateList
    {
        public string Date { get; set; }
        public List<Events.Diner> EventList { get; set; }

        public TasteDateList(string date, List<Events.Diner> eventList)
        {
            Date = date;
            EventList = eventList;
        }
    }
}