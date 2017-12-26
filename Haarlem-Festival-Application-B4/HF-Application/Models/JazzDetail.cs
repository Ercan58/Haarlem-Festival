using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class JazzDetail
    {
        public int Id { get; set; }
        [DisplayName("Band")]
        public string Band { get; set; }

        [DisplayName("Event image")]
        public string imagePath { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Location Location { get; set; }
    }
}