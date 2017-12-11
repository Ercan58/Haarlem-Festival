using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models;

namespace HF_Application.Models.ViewModel
{
    public class RestaurantModel
    {
        public IEnumerable<FoodType> ListOfSixFoodtypes { get; set; }
        public IEnumerable<FoodType> ListOfThreeFoodtypes { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}