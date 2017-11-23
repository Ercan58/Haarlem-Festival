using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HF_Application.Models.Events
{
    [Table("Diner")]
    public class Diner : EventFestival
    {
        public int Session { get; set; }
        public string RestaurantName { get; set; }
        public FoodType FoodType { get; set; }
    }
}