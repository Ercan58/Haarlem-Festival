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
        HaarlemFestivalContext db = new HaarlemFestivalContext();

        public TasteController()
        {
            AllFoodTypes = new List<FoodType>();

            this.AllFoodTypes = dinerrp.GetAllFoodtypes();
        }

        public ActionResult Details(int id)
        {
            RestaurantDetailModel restaurantDetailModel = new RestaurantDetailModel();
            restaurantDetailModel.restaurant = dinerrp.GetRestaurant(id);
            restaurantDetailModel.DinerEvents = db.Diners.Where(d => d.RestaurantId == id).ToList();


            return View(restaurantDetailModel);
        }

        // GET: Diners
        public ActionResult Index(int? id)
        {
            RestaurantModel restaurantmodel = new RestaurantModel();
            restaurantmodel.ListOfFoodtypes = AllFoodTypes;


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
