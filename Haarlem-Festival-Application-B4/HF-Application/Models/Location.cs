using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models.Enum;

namespace HF_Application.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Remarks { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public int PhoneNumber { get; set; }
        public Hall Hall { get; set; }
    }
}