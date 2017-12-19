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

        //public List<string> DaySelectionFilter()
        //{
        //    List<string> DaySelectionFilter = new List<string>();
        //    //return DaySelectionFilter = db.Jazzs.Select(s => s.StartDate.ToShortDateString().ToString()).Distinct().ToList();
        //    return DaySelectionFilter = db.Jazzs.Select(s => DbFunctions.TruncateTime(s.StartDate).ToString()).Distinct().ToList();
        //}

        public List<Jazz> GetJazzEvents(string DayFilter)
        {
            List<Jazz> JazzEventByDate = new List<Jazz>();

                return JazzEventByDate = (db.Jazzs
                .Where(s=>DbFunctions.TruncateTime(s.StartDate).ToString() == DayFilter)
                .Include(a=>a.Location)
                .ToList());
            
            //return JazzEventByDate = db.Jazzs.Where(a => a.StartDate.ToShortDateString() == DayFilter).Include(l => l.Location).ToList();
            
        }
    }
}