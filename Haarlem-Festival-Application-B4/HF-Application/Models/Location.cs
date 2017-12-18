using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Seats { get; set; }

        // Dit is nodig om ervoor te zorgen dat de default value in een selectlist kan worden opgehaald
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}