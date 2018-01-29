using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Interface;
using HF_Application.Controllers;
using HF_Application.Models;
using HF_Application.Models.Events;
using HF_Application.Models.ViewModel;
using System.Data;
using System.Data.Entity;


namespace HF_Application.Repositories
{
    public class CartRepository : ICartRepository
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();
        //TODO: CART Repository 
        //todo: add item to list via constr
        public List<OrderItem> Additem(int itemid, int aantal, string Question, FestivalEvent festivalEvent, int prijs)
        {
            int Orderid = -1;
            List<OrderItem> items = new List<OrderItem>();
            
            OrderItem items1 = new OrderItem(itemid, Orderid, aantal, Question, festivalEvent, prijs);

            items.Add(items1);

            return items;
        }

        //todo: andere lis t zonder festivalevent object voor db toevoegen 
        public List<OrderItem> Additemzonderevent(int itemid, int aantal, string Question, int prijs)
        {
            int Orderid = -1;
            List<OrderItem> items = new List<OrderItem>();

            OrderItem items1 = new OrderItem(itemid, Orderid, aantal, Question, prijs);

            items.Add(items1);

            return items;

        }

        //todo: getevnt met id in 
        public FestivalEvent GetbesteldEvent(int eventid)
        {
            FestivalEvent talk = db.FestivalEvent.Where(a => a.ID == eventid).SingleOrDefault();

            return talk;
        }

        //todo: add order to db betaald 
        public int PlaceOrder(int userid)
        {
            int statusid = 1;
            string remark = "betaald";
            int invoice = 1;
            DateTime datebesteld = DateTime.Now;
            DateTime datepayed = DateTime.Now;
            Order order = new Order(userid, statusid, remark,invoice, datebesteld, datepayed);
            db.Orders.Add(order);
            db.SaveChanges();

            int lastorderid = db.Orders.OrderByDescending(o => o.Id).FirstOrDefault().Id;

            return lastorderid;
        }

        //todo: add order to db wishlist
        public int SaveOrder(int userid)
        {
            int statusid = 0;
            string remark = "Saved";
            int invoice = 0;
            DateTime datebesteld = DateTime.Now;
            DateTime datepayed = DateTime.Now;
            Order order = new Order(userid, statusid, remark, invoice, datebesteld, datepayed);
            db.Orders.Add(order);
            db.SaveChanges();

            int lastorderid = db.Orders.OrderByDescending(o => o.Id).FirstOrDefault().Id;

            return lastorderid;
        }

        //todo: add order items to db 
        public void Additemsdb(OrderItem item)
        {
            db.OrderItems.Add(item);
            db.SaveChanges();
        }


        //todo: get alle orders die je gekocht hebt 
        public List<OrderItem> GetOrders(int userid, int statusid)
        {
            List<Order> ordersids = new List<Order>();
            List<OrderItem> orderites = new List<OrderItem>();
            //var orders1 = db.Orders.Where(o => o.UserId == 1).ToList();

            foreach (Order item in db.Orders.Where(o => o.UserId == userid && o.statusId == statusid).ToList())
            {
                ordersids.Add(item);
           
            }

            foreach (var item in ordersids)
            {
                foreach (OrderItem orderitem in db.OrderItems.Where(b => b.OrderId == item.Id).Include(b => b.Item).ToList())
                {
                    orderites.Add(orderitem);
                }

            }

            return orderites;
        }
    }
}