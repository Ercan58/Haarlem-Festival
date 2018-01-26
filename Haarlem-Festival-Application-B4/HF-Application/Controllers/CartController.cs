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
        CartRepository cartRepository = new CartRepository();
        // GET: Cart
        public ActionResult Index()
        {
            CartModel CartModel = new CartModel();

            CartModel = Session["CurrentWishlist"] as CartModel;



            return View();
        }

        public ActionResult AddToCart(int eventid, int userid, string Question, int aantal)
        {
           
            CartModel cartModel = new CartModel();
            if (Session["CurrentWishlist"] != null)
            {
                cartModel = Session["CurrentWishlist"] as CartModel;

                List<OrderItem> Old = new List<OrderItem>();
                Old = cartModel.AllOrderitems; 

                List<OrderItem> New = new List<OrderItem>();
                FestivalEvent curentevent = cartRepository.GetbesteldEvent(eventid);
                New = cartRepository.Additem(eventid, aantal, Question, curentevent);
                New.AddRange(Old);
            

                cartModel.AllOrderitems = New;
                Session["CurrentWishlist"] = cartModel;
                return View(cartModel);
            }

            FestivalEvent talk1 = cartRepository.GetbesteldEvent(eventid);
            cartModel.AllOrderitems = cartRepository.Additem(eventid, aantal, Question,talk1 );
            cartModel.AllOrderdetailtodb = cartRepository.Additemzonderevent(eventid, aantal, Question);

            Session["CurrentWishlist"] = cartModel;

            return View(cartModel);
        }

        public ActionResult DeleteItem(int id)
        {
            CartModel cartModel = new CartModel();

            cartModel = Session["CurrentWishlist"] as CartModel;

            List<OrderItem> Old = new List<OrderItem>();
            Old = cartModel.AllOrderitems;

            foreach (var item in Old.ToList())
            {
                if (item.ItemId == id)
                {
                    Old.Remove(item);
                }

            }

            cartModel.AllOrderitems = Old;


            Session["CurrentWishlist"] = cartModel;

            return View(cartModel);
        }

        public ActionResult PlaceOrder()
        {
            int userid;
            if (Session["UserId"] != null)
            {
                userid = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                userid = 3; // Guest in de db 
            }

            int orderid = cartRepository.PlaceOrder(userid);  // maak order en get zjn id voor toevoegen items 

            CartModel cartModel = new CartModel();
            cartModel = Session["CurrentWishlist"] as CartModel;

            foreach (var item111 in cartModel.AllOrderdetailtodb)
            {
                item111.OrderId = orderid;
                cartRepository.Additemsdb(item111);

            }
           

            return View();
        }
    }
}