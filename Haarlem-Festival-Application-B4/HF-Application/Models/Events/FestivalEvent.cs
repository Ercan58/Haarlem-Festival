using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace HF_Application.Models
{
    public abstract class FestivalEvent
    {
        public int ID { get; set; }
        public string CartDescription { get; set; }
        public string CartTitle { get; set; }
        public TicketType TicketType { get; set; }
        public double TicketPrice { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
         

    }
}