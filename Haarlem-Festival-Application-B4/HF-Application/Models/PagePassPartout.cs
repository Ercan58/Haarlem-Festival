using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class PagePassPartout
    {
        public int Id { get; set; }
        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}