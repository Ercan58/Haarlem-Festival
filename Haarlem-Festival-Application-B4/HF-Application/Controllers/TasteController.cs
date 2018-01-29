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
        //Aanmaken van repositorys
        IDinerRepository dinerrp = new DinerRepository();
        private List<FoodType> AllFoodTypes;

        public TasteController()
        {
            AllFoodTypes = new List<FoodType>();

            this.AllFoodTypes = dinerrp.GetAllFoodtypes();
        }

        public ActionResult Details(int id)
        {
            List<SelectListItem> dinergroup = new List<SelectListItem>();
            List<SelectListItem> aantalpersonen = new List<SelectListItem>();

            List<Diner> dinersevenements = new List<Diner>();
            

            RestaurantDetailModel restaurantDetailModel = new RestaurantDetailModel();
            restaurantDetailModel.restaurant = dinerrp.GetRestaurant(id);
            dinersevenements = dinerrp.GetAvailableDates(id);
            restaurantDetailModel.diner = dinerrp.GetDinerEvent(id);

            foreach (Diner diner in dinersevenements)
            {
                dinergroup.Add(


                    new SelectListItem
                    {
                        Value = diner.ID.ToString(),
                        Text = "Date: " + diner.StartDate.ToString("dd/MM") + " Time" + diner.StartDate.ToString("HH:mm") + "-" + diner.EndDate.ToString("HH:mm"),

                    });
                
            
            }
            for(int a=1; a<10; a++)
            {
                aantalpersonen.Add(
                new SelectListItem
                {
                    Value = a.ToString(),
                    Text = a.ToString(),

                });
            }

            restaurantDetailModel.DinerEvents = dinergroup;
            restaurantDetailModel.NumberPersons = aantalpersonen;
            restaurantDetailModel.CrossTalkEvents = dinerrp.GetRandomTalksEvent(2);
            restaurantDetailModel.HearCrossEvents = dinerrp.GetRandomJazzEvent(2);

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
