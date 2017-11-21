using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public int CustomerId {get;set;}

        public int ItemId { get; set; }

        public User Customer { get; set; }
        public OrderItem Item { get; set; }
    }
}