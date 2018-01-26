using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class SalesItem
    {
        public int Id;
        public string CartTitle;
        public string CartDescription;
        public DateTime StartDate;
        public double TicketPrice;
        public int SeatsSold;
        public double Revenue;
        public int Seats;
        public int FreeSeats;

        public SalesItem() { }
    }
}