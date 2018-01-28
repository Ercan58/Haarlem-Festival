using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HF_Application.Models.Events
{
    [Table("Talk")]
    public class Talk : FestivalEvent
	{
        public string Interview { get; set; }
        public string ReservationInfo { get; set; }
        [DisplayName("Event Photo")]
        public string ImagePath { get; set; }

        [DisplayName("Event Location")]
        public Location Location { get; set; }
    }
}