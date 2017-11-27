using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;
using System.Data.Entity;



namespace WebAppHF.Repositories
{
    public class Database : DbContext
    {
        public Database() : base("name=Database")
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Jazz> Jazzs { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<AdminAccount> AdminAccounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RestaurantSession> RestaurantReservations { get; set; }
    }
}