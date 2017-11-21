using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class PageEvent
    {
        public int Id { get; set; }
        public int PassPartoutId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public PagePassPartout PassPartout { get; set; }



    }
}