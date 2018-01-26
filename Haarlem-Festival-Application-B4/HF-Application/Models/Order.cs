using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models.Enum;

namespace HF_Application.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int statusId { get; set;}
        public string Remark { get; set; }
        public int Invoice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderPayed { get; set; }
        public User User { get; set; }
        public Status status { get; set; }

        public Order(int userid, int statusid, string remark, int invoice, DateTime orderdate, DateTime orderpayed)
        {
            UserId = userid;
            statusId = statusid;
            Remark = remark;
            Invoice = invoice;
            OrderDate = orderdate;
            OrderPayed = orderpayed;


        }
        public Order()
        {
        }

    }  
}