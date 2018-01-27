using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models.ViewModel
{
    public class CartModel
    {
        public List<OrderItem> AllOrderitems { get; set; }

        public List<OrderItem> AllOrderdetailtodb { get; set; }

        public float totaal { get; set; }
    }
}