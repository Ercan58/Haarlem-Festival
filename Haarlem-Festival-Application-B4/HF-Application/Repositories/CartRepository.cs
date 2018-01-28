﻿using System;
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

        public List<OrderItem> Additem(int itemid, int aantal, string Question, FestivalEvent festivalEvent, int prijs)
        {
            int Orderid = -1;
            List<OrderItem> items = new List<OrderItem>();
            
            OrderItem items1 = new OrderItem(itemid, Orderid, aantal, Question, festivalEvent, prijs);

            items.Add(items1);

            return items;
        }

        public List<OrderItem> Additemzonderevent(int itemid, int aantal, string Question, int prijs)
        {
            int Orderid = -1;
            List<OrderItem> items = new List<OrderItem>();

            OrderItem items1 = new OrderItem(itemid, Orderid, aantal, Question, prijs);

            items.Add(items1);

            return items;

        }

        public FestivalEvent GetbesteldEvent(int eventid)
        {
            FestivalEvent talk = db.FestivalEvent.Where(a => a.ID == eventid).SingleOrDefault();

            return talk;
        }

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

        public void Additemsdb(OrderItem item)
        {
            db.OrderItems.Add(item);
            db.SaveChanges();
        }
    }
}