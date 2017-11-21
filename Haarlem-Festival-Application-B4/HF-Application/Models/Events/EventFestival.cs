using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public abstract class EventFestival
    {
        public int ID { get; set; }
        public int LocationId { get; set; }
        public string CartDescription { get; set; }
        public string CartTitle { get; set; }
        public int Price { get; set; }
        public int Seats { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        public Location Location { get; set; }
    }
}