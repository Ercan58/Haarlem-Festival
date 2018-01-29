using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models;
using HF_Application.Models.Events;

namespace HF_Application.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<Jazz> jazzEvents { get; set; }
        public List<Restaurant> restoList { get; set; }
        public List<Talk> talkList { get; set; }
    }
}