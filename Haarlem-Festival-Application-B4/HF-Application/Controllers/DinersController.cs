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
            return Restaurants = db.Restaurants.ToList();
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

        // GET: Diners
        public ActionResult Index(int? id)
        {
            RestaurantModel restaurantmodel = null;
            if (id== null)
            {
                //Pakket samenvoegen zodat dit gebruiksklaar is...
                restaurantmodel = new RestaurantModel();
                restaurantmodel.ListOfSixFoodtypes = FirstTillSixFoodtypes;
                restaurantmodel.ListOfThreeFoodtypes = sevenTillNineFoodtypes;
                restaurantmodel.Restaurants = AllRestaurants;
            }
            else
            {
                restaurantmodel = new RestaurantModel();
            }

            return View(restaurantmodel);   
        }

    }
}
