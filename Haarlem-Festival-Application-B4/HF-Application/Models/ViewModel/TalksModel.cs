using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Models;
using HF_Application.Models.Events;

namespace HF_Application.Models.ViewModel
{
    public class TalksModel
    {
        public List<Talk> AllTalkEvents { get; set; }
        public List<Talk> CrossTalkEvents { get; set; }
    }
}