using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class OrderItem
    { 
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }

        public int Aantal { get; set; }

        public string Opmerking { get; set; }

        public int Prijs { get; set; }
        public FestivalEvent Item { get; set; }
        public Order Order { get; set; }



        public OrderItem(int itemid, int orderid, int aantal,  string question , FestivalEvent festivalEvent, int prijs)
        {
            ItemId = itemid;
            OrderId = orderid;
            Aantal = aantal;
            Prijs = prijs;
            Opmerking = question;
            Item = festivalEvent;

        }

        public OrderItem(int itemid, int orderid, int aantal, string question, int prijs)
        {
            ItemId = itemid;
            OrderId = orderid;
            Aantal = aantal;
            Prijs = prijs;
            Opmerking = question;
           

        }
        public OrderItem()
        {

        }
    }
}