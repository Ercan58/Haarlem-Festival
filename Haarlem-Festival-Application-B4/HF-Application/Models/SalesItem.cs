using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class SalesItem
    {
        public int Id { get; set; }
        public string CartTitle { get; set; }
        public string CartDescription { get; set; }
        public DateTime StartDate { get; set; }
        public double TicketPrice { get; set; }
        public int SeatsSold { get; set; }
        public double Revenue { get; set; }
        public int Seats { get; set; }
        public int FreeSeats { get; set; }

        public SalesItem() { }
    }
}