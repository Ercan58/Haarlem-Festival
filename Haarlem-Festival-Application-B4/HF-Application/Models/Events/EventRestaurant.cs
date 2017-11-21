using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models.Enum;

namespace HF_Application.Models.Events
{
    public class EventRestaurant : Event
    {
        public int Session { get; set; }
        public string RestaurantName { get; set; }
        public FoodType FoodType { get; set; }
    }
}