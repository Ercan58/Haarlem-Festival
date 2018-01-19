using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HF_Application.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "select if you are an admin or not.")]
        public bool Admin { get; set; }
        // name // 

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string Email { get; set; }


        // mail //
        [Required(ErrorMessage = "Email is required.")]
      //  [RegularExpression(@"^[\w\-\.\+] +\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$", ErrorMessage = "Please enter vaild email")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Please confirm your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string Salt { get; set; }

    }
}