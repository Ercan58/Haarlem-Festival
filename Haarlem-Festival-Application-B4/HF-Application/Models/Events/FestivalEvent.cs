using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HF_Application.Models
{
    public abstract class FestivalEvent
    {
        public int ID { get; set; }

        [DisplayName("Event Description")]
        public string CartDescription { get; set; }

        [DisplayName("Event Name")]
        public string CartTitle { get; set; }

        public TicketType TicketType { get; set; }

        [DisplayName("Ticket Price")]
        public double TicketPrice { get; set; }

        [DisplayName("End Date and Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddThh:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [DisplayName("Start Date and Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddThh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
         

    }
}