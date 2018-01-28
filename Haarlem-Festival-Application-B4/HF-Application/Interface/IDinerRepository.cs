using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models;
using HF_Application.Models.Events;

namespace HF_Application.Interface
{
    public interface IDinerRepository
    {
        List<FoodType> GetAllFoodtypes();
        List<Restaurant> GetAllRestaurants();
        List<Restaurant> GetRestaurants(int id);

        Restaurant GetRestaurant(int id);
        List<Diner> GetAvailableDates(int id);
        Diner GetDinerEvent(int id);
        List<Talk> GetRandomTalksEvent(int aantal);
        List<Jazz> GetRandomJazzEvent(int aantal);
    }
}