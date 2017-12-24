using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HF_Application.Models.Events
{
    [Table("Jazz")]
    public class Jazz : FestivalEvent
    {
        [DisplayName("Band Name")]
        public string Band { get; set; }
        [DisplayName("Event Image")]
        public string imagePath { get; set; }
        public int eventDayID { get; set; }

        [DisplayName("Event Location")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Location Location { get; set; }

        //public Jazz() { }
        //public Jazz(JazzModel model)
        //{
        //    CartTitle = model.CartTitle;
        //    Band = model.Band;
        //    Location = model.Location;
        //    TicketPrice = model.TicketPrice;
        //    StartDate = model.StartDate;
        //    EndDate = model.EndDate;
        //    CartDescription = model.CartDescription;
        //    imagePath = model.imagePath;
        //}
    }
}