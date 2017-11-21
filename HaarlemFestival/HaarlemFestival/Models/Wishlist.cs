using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Models
{
    public class Wishlist
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public User Customer { get; set; }
    }
}