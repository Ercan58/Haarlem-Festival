﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }

        public string imagePath { get; set; }

        public Location Location { get; set; }

        public virtual ICollection<RestaurantFoodtype> FoodTypes { get; set; }

    }
}