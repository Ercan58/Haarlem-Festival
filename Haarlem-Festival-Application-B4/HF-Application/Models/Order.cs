using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Invoice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderPayed { get; set; }

    }  
}