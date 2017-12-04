﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HF_Application.Models.Events
{
    [Table("Diner")]
    public class Diner : FestivalEvent
    {
        public int Session { get; set; }
        public string RestaurantName { get; set; }
        public string imagePath { get; set; }
        public FoodType FoodType1 { get; set; }
        public FoodType FoodType2 { get; set; }
        public FoodType FoodType3 { get; set; }
    }
}