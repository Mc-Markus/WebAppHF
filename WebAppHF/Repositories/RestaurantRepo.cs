﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class RestaurantRepo : IResetaurantRepo
    {
        private Database db = new Database();
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurant = db.Restaurants.ToList();
            return restaurant;
        }

        public Restaurant GetRestaurantByID(int ID)
        {
            using (Database database = new Database())
            {
                Restaurant restaurant;

                restaurant = database.Restaurants.SingleOrDefault(e => e.ID == ID);

                return restaurant;
            }
        }

        public List<Restaurant> GetRestaurants()
        {
            using (Database database = new Database())
            {
                IEnumerable<Restaurant> restaurants;

                restaurants = database.Restaurants.AsEnumerable();

                return restaurants.ToList();
            }

            
        }
    }
}