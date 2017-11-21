using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFestival.Interface;

namespace HaarlemFestival.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int EvenChoiceId { get; set; }

        public FestivalEvent EventChoice { get; set; }
    }
}