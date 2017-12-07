using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class TourGuideLang
    {
        public int Id { get; set; }
        public TourGuid tourGuide { get; set; }
        public TourLanguage tourLanguage { get; set; }
    }
}