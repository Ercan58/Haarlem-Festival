using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models.Events
{
    public class EventHistoric:Event
    {

        public int FamilyPrice { get; set; }
        public string ReservationInfo { get; set; }

    }
}