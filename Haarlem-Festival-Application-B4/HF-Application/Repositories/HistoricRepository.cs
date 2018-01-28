using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Interface;
using HF_Application.Controllers;
using HF_Application.Models;
using HF_Application.Models.Events;
using HF_Application.Models.ViewModel;
using System.Data;
using System.Data.Entity;

namespace HF_Application.Repositories
{
    public class HistoricRepository : IHistoricRepository
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();
        public List<Historic> GetAllHistoryEvents()
        {
            List<Historic> HistoryEvents = new List<Historic>();
            return HistoryEvents = db.Historics.Include(a => a.tourGuid).Include(b => b.Location).ToList();
        }

        public List<Historic> GetHistoricEvents(DateTime datetime)
        {
            List<Historic> JazzEventByDate = new List<Historic>();

                return JazzEventByDate = (db.Historics.Where(s=> s.StartDate.Year == datetime.Year && s.StartDate.Day==datetime.Day && s.StartDate.Month == datetime.Month).Include(a=>a.Location).ToList());
        }
    }
}