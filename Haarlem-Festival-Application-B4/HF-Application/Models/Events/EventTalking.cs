using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models.Events
{
    public class EventTalking : Event
    {
        public string Interview { get; set; }
        public string ReservationInfo { get; set; }
    }
}