using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Interface;
using HF_Application.Controllers;
using HF_Application.Models;
using System.Data;
using System.Data.Entity;
using HF_Application.Models.Events;

namespace HF_Application.Repositories
{
    public class DinerRepository:IDinerRepository
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();
        public List<FoodType> GetAllFoodtypes()
        {
            List<FoodType> FoodTypes = db.Foodtypes.ToList();
            return FoodTypes;
        }

        public List<Diner> GetAvailableDates(int id)
        {
            return db.Diners.Where(d => d.RestaurantId == id && d.Seats != 0).ToList();
        }

        public Diner GetDinerEvent(int id)
        {
            return db.Diners.FirstOrDefault(d => d.RestaurantId == id);
        }

        public List<Talk> GetRandomTalksEvent(int aantal)
        {
           return db.Talks.OrderBy(r => Guid.NewGuid()).Take(aantal).ToList();
        }

        public List<Jazz> GetRandomJazzEvent(int aantal)
        {
            return db.Jazzs.OrderBy(j => Guid.NewGuid()).Take(2).ToList();
        }

        public List<Restaurant> GetAllRestaurants()
        {
            List<Restaurant> Restaurants = new List<Restaurant>();
            return Restaurants = db.Restaurants.Include(a => a.FoodTypes).Include(b => b.Location).ToList();
        }

        public List<Restaurant> GetRestaurants(int id)
        {

            List<Restaurant> restaurants = new List<Restaurant>();

            var foodtypes = db.RestaurantFoodtypes.Where(f => f.Foodtype.Id == id).Include(r => r.Restaurant).Include(f => f.Foodtype).Include(b => b.Restaurant.Location).ToList();

            foreach (RestaurantFoodtype restaurantfoodtype in foodtypes)
            {
                restaurants.Add(restaurantfoodtype.Restaurant);
            }

            return restaurants;
        }

        public Restaurant GetRestaurant(int id)
        {
           Restaurant restaurant = db.Restaurants.Where(a => a.Id == id).Include(n => n.Location).Include(b => b.FoodTypes).SingleOrDefault();
           return restaurant;
        }

    }
}