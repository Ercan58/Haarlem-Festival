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
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Text;
using System.Data;

namespace HF_Application.Controllers
{
    public class CartController : Controller
    {
        StringBuilder table = new StringBuilder();
        CartRepository cartRepository = new CartRepository();
       
        
        // GET: Cart
        //TODO: Cart Controller Index moel = session returnt parameter Model 
        public ActionResult Index()
        {
            CartModel cartModel = new CartModel();

            cartModel = Session["CurrentWishlist"] as CartModel;

            return View(cartModel);
        }

        //TODO: Action AddtoCart parameters in eventid, userid enzo 
        public ActionResult AddToCart(int eventid, int userid, string Question, int aantal, int prijs)
        {
            // om totaal te berkenen
            int totaal = 0;
            CartModel cartModel = new CartModel();

            //TODO: If session != null => Model = session 
            if (Session["CurrentWishlist"] != null)
            {
                cartModel = Session["CurrentWishlist"] as CartModel;

                //TODO: Session oude orderitems in een lijst 
                List<OrderItem> Old = new List<OrderItem>();
                Old = cartModel.AllOrderitems;

                //TODO: New lijst van orderitems  aanmaken
                List<OrderItem> New = new List<OrderItem>();

                //TODO: Get current event via Id 
                FestivalEvent curentevent = cartRepository.GetbesteldEvent(eventid);

                //TODO: Item toevoegen aan de niewe lijs 
                New = cartRepository.Additem(eventid, aantal, Question, curentevent, prijs);

                //TODO: OUDE EN NIEWE list mixen 
                New.AddRange(Old);
         
                //TODO: SUBTOTAL berekenen foreach item en totaal alles 
                foreach (var item in New)
                {
                    int subtotaal = (item.Aantal * item.Prijs);
                    totaal = totaal + subtotaal;
                }
                //TODO: return Model met totaal eb list items 
                cartModel.totaal = totaal;
                cartModel.AllOrderitems = New;

                //TODO: Session == model 
                Session["CurrentWishlist"] = cartModel;
                return View(cartModel);
            }

            //TODO: If session == null 
            //todo:get event 
            FestivalEvent eventi = cartRepository.GetbesteldEvent(eventid);

            //todo: list all orderitems = additem to list via constr met Objrct orderitemsdetails 
            cartModel.AllOrderitems = cartRepository.Additem(eventid, aantal, Question, eventi, prijs);

            //todo: list items voor db zonder item event 
            cartModel.AllOrderdetailtodb = cartRepository.Additemzonderevent(eventid, aantal, Question, prijs);

            //todo: totaal berekenen 
            foreach (var item in cartModel.AllOrderitems)
            {
                int subtotaal = (item.Aantal * item.Prijs);
                totaal = totaal + subtotaal;
            }
            cartModel.totaal = totaal;

            //todo: session = cartmodel 
            Session["CurrentWishlist"] = cartModel;

            return View(cartModel);
        }

        //TODO: Action2 Delete Item ID IN 
        public ActionResult DeleteItem(int id)
        {
            CartModel cartModel = new CartModel();
            //todo: cartmodel = session 
            cartModel = Session["CurrentWishlist"] as CartModel;

            //todo: list orderitems aanmaken
            List<OrderItem> Old = new List<OrderItem>();

            //todo: list == model list
            Old = cartModel.AllOrderitems;

            //todo: foreach item in list remove als item.id = id
            foreach (var item in Old.ToList())
            {
                if (item.ItemId == id)
                {
                    Old.Remove(item);
                }

            }

            //todo: cartmodel = new list
            cartModel.AllOrderitems = Old;

            //todo: session == model
            Session["CurrentWishlist"] = cartModel;

            //todo:return model kan ook to action maar ja
            return View(cartModel);
        }

        //TODO: Action3 go to Checkout page 
        public ActionResult Afrekenen()
        {
            CartModel cartModel = new CartModel();

            //todo: cartmodel == session
            cartModel = Session["CurrentWishlist"] as CartModel;

            //todo: return model new view 
            return View(cartModel);
        }


        //TODO: na betalen place order in db 
        public ActionResult PlaceOrder()
        {
            int userid;
            //todo als session userid != 0 => userid = session 
            if (Session["UserId"] != null)
            {
                userid = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                userid = 3; //todo: zonder inloggen zal als gast in de db opgeslagen worden
            }

            //TODO:vanwege db fout maak eerst order en get zjn id voor toevoegen items met orderid die je gemaakt hebt 
            int orderid = cartRepository.PlaceOrder(userid);  

            //todo: cartmodel = session 
            CartModel cartModel = new CartModel();
            cartModel = Session["CurrentWishlist"] as CartModel;

            //todo: foreach item in model item.orderid = orderid die je net gemaakr hebt
            foreach (var item111 in cartModel.AllOrderdetailtodb)
            {
                item111.OrderId = orderid;
                //todo: addorderitems to db 
                cartRepository.Additemsdb(item111);

            }

            //todo: session == null 
            Session["CurrentWishlist"] = null;
            //todo: return view leeg 
            return View();
        }

        //TODO: Action3 SaveOrder voor later in de  wishlist  zelfde als alleen statusid = 0 
        public ActionResult SaveOrder()
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

            int orderid = cartRepository.SaveOrder(userid);  // maak order en get zjn id voor toevoegen items 

            CartModel cartModel = new CartModel();
            cartModel = Session["CurrentWishlist"] as CartModel;

            foreach (var item111 in cartModel.AllOrderdetailtodb)
            {
                item111.OrderId = orderid;
                cartRepository.Additemsdb(item111);

            }

            Session["CurrentWishlist"] = null;
            User user = Session["User"] as User;
            return RedirectToAction("LoggedIn", "User", user);
        }

        public ActionResult ClearCart()
        {
            Session["CurrentWishlist"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Orders()
        {
            int statusid = 1;
            int userid = Convert.ToInt32(Session["UserId"]);
            OrdersModel orders = new OrdersModel();
           orders.orderitems =  cartRepository.GetOrders(userid, statusid);

            return View(orders);
        }

        //TODO: ACTION Wishlist extra voor eef
        public ActionResult Wishlist()
        {
            int statusid = 0;
            int userid = Convert.ToInt32(Session["UserId"]);
      
            CartModel cartModel = new CartModel();
            //todo: get orders voor userd wannner statusid = 0 [niet betaald ]
            cartModel.AllOrderitems = cartRepository.GetOrders(userid, statusid);

            return View(cartModel);
        }

        //todo: extra eef afrekenen wishlist 
        public ActionResult AfrekenenWishlist(CartModel cartModel)
        {
            Session["CurrentWishlist"] = cartModel as CartModel;

            return RedirectToAction("Afrekenen");
        }

        //TODO: action Export items to Word file Datatable 
        public ActionResult ExportOrder()
        {
            CartModel cartModel = new CartModel();
            //todo: cartmodel = session 
            cartModel = Session["CurrentWishlist"] as CartModel;
            DataTable dt = new DataTable();

            //todo: add colums to datatable 
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Aantal", typeof(int));
            dt.Columns.Add("Prijs", typeof(int));
            dt.Columns.Add("Subtotaal", typeof(string));

            //todo: foreach ietm in list add rows 
            foreach (var item in cartModel.AllOrderitems)
            {
                dt.Rows.Add(item.Item.CartTitle, item.Item.CartDescription, item.Aantal, item.Prijs, (item.Aantal * item.Prijs));
            
            }
          
            //todo: gridview aanmaken datasourse = datatable 
            var gridview = new GridView();
            gridview.DataSource = dt;
            gridview.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            //todo: addheader - file name 
            Response.AddHeader("content-disposition", "attachment; filename=Haarlem-Festival-your-OrderItems.doc");
            Response.ContentType = "application/ms-word";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gridview.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            //todo: terug naar action 
            return RedirectToAction("Afrekenen");
        }
    }
}