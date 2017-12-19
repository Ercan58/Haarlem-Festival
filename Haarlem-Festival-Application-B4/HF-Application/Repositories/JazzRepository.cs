using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HF_Application.Models;
using HF_Application.Models.Events;
using HF_Application.Models.ViewModel;

namespace HF_Application.Repositories
{
    public class JazzRepository : IJazzRepository
    {

        private HaarlemFestivalContext db = new HaarlemFestivalContext();
        public List<Jazz> GetAllJazzEvents()
        {
            List<Jazz> JazzEvents = new List<Jazz>();
            return JazzEvents = db.Jazzs.Include(a => a.Location).ToList();
        }

        //public List<Jazz> GetSelectionFilter()
        //{
        //    List<Jazz> JazzEventsDate = new List<Jazz>();
        //    return JazzEventsDate = db.Jazzs.Select(a => a.StartDate).Distinct();
        //}
    }
}