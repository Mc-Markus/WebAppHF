using System;
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

        public Restaurant GetRestaurant(int restaurantId)
        {
            Restaurant contact = db.Restaurants.Find(restaurantId);
            return contact;
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