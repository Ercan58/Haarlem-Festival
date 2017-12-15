using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HF_Application.Models.Events
{
    public class JazzModel : FestivalEvent
	{
        [Required(ErrorMessage = "A name for this event is required")]
        [MinLength(2, ErrorMessage = "The name should be at least two characters long")]
        [Display(Name = "Event Name")]
        public new string CartTitle { get; set; }

        [Required(ErrorMessage = "The name of the band playing at this event is required")]
        [MinLength(2, ErrorMessage = "The name should be at least two characters long")]
        [Display(Name = "Band Name")]
        public string Band { get; set; }

        [Required(ErrorMessage = "The event location is required")]
        [Display(Name = "Event Location")]
        public Location Location { get; set; }

        [Required(ErrorMessage = "A price for this event is required")]
        [Display(Name = "Ticket Price")]
        public new double TicketPrice { get; set; }

        [Required(ErrorMessage = "A date for this event is required.")]
        [Display(Name = "Start Date and Time")]
        public new DateTime StartDate { get; set; }

        [Required(ErrorMessage = "A date for this event is required")]
        [Display(Name = "End Date and Time")]
        public new DateTime EndDate { get; set; }

        [Required(ErrorMessage = "A description for this event is required")]
        [MinLength(2, ErrorMessage = "The description should be at least two characters long")]
        [Display(Name = "Event Description")]
        public new string CartDescription { get; set; }

        [Display(Name = "Image URL")]
        public string imagePath { get; set; }

    }
}