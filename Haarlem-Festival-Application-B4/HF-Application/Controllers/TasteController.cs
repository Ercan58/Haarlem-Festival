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
using HF_Application.Interface;
using HF_Application.Repositories;

namespace HF_Application.Controllers
{
    public class TasteController : Controller
    {
        IDinerRepository dinerrp = new DinerRepository();
        private List<FoodType> AllFoodTypes;
        private List<FoodType> FirstTillSixFoodtypes;
        private List<FoodType> sevenTillEndFoodtypes;

        public TasteController()
        {
            FirstTillSixFoodtypes = new List<FoodType>();
            sevenTillEndFoodtypes = new List<FoodType>();

            this.AllFoodTypes = dinerrp.GetAllFoodtypes();
            this.FirstTillSixFoodtypes = selectFoodTypes(0, 5);
            this.sevenTillEndFoodtypes = selectFoodTypes(6, AllFoodTypes.Count-1);
        }

        public List<FoodType> selectFoodTypes(int start, int end)
        {
            List<FoodType> foodtypes = new List<FoodType>();

            for(int a=start; a<=end; a++)
            {
                foodtypes.Add(AllFoodTypes[a]);
            }
            return foodtypes;
        }


        // GET: Diners
        public ActionResult Index(int? id)
        {
            RestaurantModel restaurantmodel = new RestaurantModel();
            restaurantmodel.ListOfSixFoodtypes = FirstTillSixFoodtypes;
            restaurantmodel.ListOfThreeFoodtypes = sevenTillEndFoodtypes;


            if (id== null)
            {
                //Pakket samenvoegen zodat dit gebruiksklaar is...
                restaurantmodel.Restaurants = dinerrp.GetAllRestaurants();
            }
            else
            {
                int categorieId = id.GetValueOrDefault();   
                restaurantmodel.Restaurants = dinerrp.GetRestaurants(categorieId);

            }
            return View(restaurantmodel);   
        }

    }
}
