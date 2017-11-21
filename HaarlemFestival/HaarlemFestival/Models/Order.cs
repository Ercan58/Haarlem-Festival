using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Models
{
    public class Order
    {
        public int id { get; set; }
        
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public int invoice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderPayed { get; set; }

        public User Customer { get; set; }
        public OrderItem Item { get; set; }

    }
}