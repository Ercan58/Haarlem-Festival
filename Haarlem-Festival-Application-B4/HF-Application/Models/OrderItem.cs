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
        
        public EventFestival Item { get; set; }
    }
}