using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class RestaurantFoodtype
    {
        public int Id { get; set; }
        public int RestauranttId { get; set; }
        public int FoodtypeId { get; set; }

        public Restaurant Restaurant { get; set; }
        public FoodType Foodtype { get; set; }
    }
}