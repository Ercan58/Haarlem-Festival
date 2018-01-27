using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HF_Application.Models.Events;

namespace HF_Application.Models
{
    public class JazzDetail
    {
        public Jazz JazzEvent { get; set; }
        public List<Restaurant> CrossSellingRestaurauntList { get; set; }

        public List<Talk> CrossSellingTalk { get; set; }

    }
}