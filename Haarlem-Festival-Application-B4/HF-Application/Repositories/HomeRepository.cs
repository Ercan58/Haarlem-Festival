using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HF_Application.Interface;
using HF_Application.Controllers;
using HF_Application.Models;
using System.Data;
using System.Data.Entity;
using HF_Application.Repositories;
using HF_Application.Models.Events;

namespace HF_Application.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private HaarlemFestivalContext db = new HaarlemFestivalContext();

        public List<Jazz> jazzList()
        {
            List<Jazz> list = db.Jazzs.OrderBy(j => Guid.NewGuid()).Take(4).ToList();
            return list;
        }

        public List<Restaurant> restoList()
        {
            List<Restaurant> Restaurants = new List<Restaurant>();
            return Restaurants = db.Restaurants.Include(a => a.FoodTypes).Include(b => b.Location).Take(4).ToList();
        }

        public List<Talk> talkList()
        {
            List<Talk> list = db.Talks.OrderBy(j => Guid.NewGuid()).Take(3).ToList();
            return list;
        }
    }
}