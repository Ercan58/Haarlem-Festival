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

        public List<OrderItem> Additem(int itemid, int aantal, string Question, FestivalEvent orderitem)
        {
            int Orderid = -1;
            int prijs = 0;
            List<OrderItem> items = new List<OrderItem>();
            OrderItem items1 = new OrderItem(itemid, Orderid, aantal, Question, prijs, orderitem);

            items.Add(items1);

            return items;
        }

        public FestivalEvent GetbesteldEvent(int eventid)
        {
            FestivalEvent talk = db.FestivalEvent.Where(a => a.ID == eventid).SingleOrDefault();

            return talk;
        }
    }
}