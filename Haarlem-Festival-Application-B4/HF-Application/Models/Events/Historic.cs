using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HF_Application.Models.Events
{
    [Table("Historic")]
    public class Historic: FestivalEvent
    {

        [DisplayName("Family Price")]
        public int FamilyPrice { get; set; }
        public string ReservationInfo { get; set; }

        [DisplayName("Tour Guide")]
        public TourGuid tourGuid { get; set; }

        [DisplayName("Event Location")]
        public Location Location { get; set; }


    }
}