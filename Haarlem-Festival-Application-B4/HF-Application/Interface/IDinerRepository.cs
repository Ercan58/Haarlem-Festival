using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models;

namespace HF_Application.Interface
{
    public interface IDinerRepository
    {
        List<FoodType> GetAllFoodtypes();
        List<Restaurant> GetAllRestaurants();
        List<Restaurant> GetRestaurants(int id);
    }
}