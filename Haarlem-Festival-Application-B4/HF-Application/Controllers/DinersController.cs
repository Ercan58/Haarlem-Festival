using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using HF_Application.Models.Events;
using HF_Application.Models.ViewModel;

namespace HF_Application.Controllers
{
    public class DinersController : Controller
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        private List<FoodType> AllFoodTypes;
        private List<Restaurant> AllRestaurants;
        private List<FoodType> FirstTillSixFoodtypes;
        private List<FoodType> sevenTillNineFoodtypes;

        public DinersController()
        {
            AllRestaurants = new List<Restaurant>();
            FirstTillSixFoodtypes = new List<FoodType>();
            sevenTillNineFoodtypes = new List<FoodType>();


            this.AllRestaurants = GetAllRestaurants();
            this.AllFoodTypes = GetAllFoodtypes();
            this.FirstTillSixFoodtypes = selectFoodTypes(0, 5);
            this.sevenTillNineFoodtypes = selectFoodTypes(6, 8);
        }

        public List<Restaurant> GetAllRestaurants()
        {
            List<Restaurant> Restaurants = new List<Restaurant>();
            return Restaurants = db.Restaurants.Include(a=>a.FoodTypes).Include(b=>b.Location).ToList();
        }

        public List<FoodType> GetAllFoodtypes()
        {
            List<FoodType> FoodTypes = db.Foodtypes.ToList();
            return FoodTypes;
        }

        public List<FoodType> selectFoodTypes(int start, int end)
        {
            List<FoodType> foodtypes=new List<FoodType>();

            for(int a=start; a<=end; a++)
            {
                foodtypes.Add(AllFoodTypes[a]);
            }
            return foodtypes;
        }

        public List<Restaurant> GetRestaurants(int id)
        {
            List<Restaurant> restaurants = null;
            restaurants = new List<Restaurant>();

            var foodtypes = db.RestaurantFoodtypes.Where(f => f.Foodtype.Id == id).Include(r=>r.Restaurant).Include(f=>f.Foodtype).ToList();

            foreach(RestaurantFoodtype restaurantfoodtype in foodtypes)
            {
                restaurants.Add(restaurantfoodtype.Restaurant);
            }

            return restaurants;
        }

        // GET: Diners
        public ActionResult Index(int? id)
        {
            RestaurantModel restaurantmodel = null;
            restaurantmodel = new RestaurantModel();
            restaurantmodel.ListOfSixFoodtypes = FirstTillSixFoodtypes;
            restaurantmodel.ListOfThreeFoodtypes = sevenTillNineFoodtypes;


            if (id== null)
            {
                //Pakket samenvoegen zodat dit gebruiksklaar is...
                restaurantmodel.Restaurants = AllRestaurants;
            }
            else
            {
                int categorieId = id.GetValueOrDefault();   
                restaurantmodel.Restaurants = GetRestaurants(categorieId);
                
            }




            return View(restaurantmodel);   
        }

    }
}
