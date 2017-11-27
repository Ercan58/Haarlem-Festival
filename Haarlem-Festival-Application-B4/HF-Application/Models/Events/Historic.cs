﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HF_Application.Models.Events
{
    [Table("Historic")]
    public class Historic: EventFestival
    {

        public int FamilyPrice { get; set; }
        public string ReservationInfo { get; set; }

    }
}