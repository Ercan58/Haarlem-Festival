using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HF_Application.Models.Events
{
    [Table("Jazz")]
    public class Jazz : FestivalEvent
	{
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Band { get; set; }
        public string imagePath { get; set; }

        public Location Location { get; set; }

    }
}