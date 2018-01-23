using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using HF_Application.Models.Events;
using HF_Application.Models.ViewModel;
using HF_Application.Interface;
using HF_Application.Repositories;

namespace HF_Application.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            CartModel CartModel = new CartModel();

            List<OrderItem> Old = new List<OrderItem>();
            Old = Session["CurrentWishlist"] as List<OrderItem>;

            Session["CurrentWishlist"] = Old;

            CartModel.AllOrderitems = Old;

            return View();
        }

        public ActionResult AddToCart(int eventid, int userid, string Question, int aantal)
        {
            CartRepository cartRepository = new CartRepository();
            CartModel CartModel = new CartModel();
            if (Session["CurrentWishlist"] != null)
            {
                List<OrderItem> Old = new List<OrderItem>();
                Old = Session["CurrentWishlist"] as List<OrderItem>;

                List<OrderItem> New = new List<OrderItem>();
                FestivalEvent talk1 = cartRepository.GetbesteldEvent(eventid);
                New = cartRepository.Additem(eventid, aantal, Question, talk1);
                New.AddRange(Old);


                CartModel.AllOrderitems = New;
                Session["CurrentWishlist"] = CartModel.AllOrderitems;
                return View(CartModel);
            }
            FestivalEvent talk = cartRepository.GetbesteldEvent(eventid);
            CartModel.AllOrderitems = cartRepository.Additem(eventid, aantal, Question, talk);

            Session["CurrentWishlist"] = CartModel.AllOrderitems;

            return View(CartModel);
        }

        public ActionResult DeleteItem(int id)
        {
            CartModel CartModel = new CartModel();

            List<OrderItem> Old = new List<OrderItem>();
            Old = Session["CurrentWishlist"] as List<OrderItem>;

            foreach (var item in Old.ToList())
            {
                if (item.ItemId == id)
                {
                    Old.Remove(item);
                }

            }

            Session["CurrentWishlist"] = Old;


            CartModel.AllOrderitems = Old;


            return View(CartModel);
        }
    }
}