using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class HaarlemFestivalContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HaarlemFestivalContext() : base("name=HaarlemFestivalContext")
        {
        }

        public System.Data.Entity.DbSet<HF_Application.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<HF_Application.Models.OrderItem> OrderItems { get; set; }

        public System.Data.Entity.DbSet<HF_Application.Models.FestivalEvent> FestivalEvent { get; set; }
        public System.Data.Entity.DbSet<HF_Application.Models.Events.Jazz> Jazzs { get; set; }
        public System.Data.Entity.DbSet<HF_Application.Models.Events.Talk> Talks { get; set; }
        public System.Data.Entity.DbSet<HF_Application.Models.Events.Diner> Diners { get; set; }
        public System.Data.Entity.DbSet<HF_Application.Models.Events.Historic> Historics { get; set; }
        public System.Data.Entity.DbSet<HF_Application.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<HF_Application.Models.Location> Locations { get; set; }
        public System.Data.Entity.DbSet<HF_Application.Models.Restaurant> Restaurants { get; set; }
        public System.Data.Entity.DbSet<HF_Application.Models.RestaurantFoodtype> RestaurantFoodtypes { get; set; }

    }
}
