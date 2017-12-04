using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class RestaurantRepo : IResetaurantRepo
    {
        private HFContext db = new HFContext();
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurant = db.Restaurants.ToList();
            return restaurant;
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
            Restaurant restaurant = db.Restaurants.Where(x => x.ID == restaurantId).SingleOrDefault();
            Restaurant contact = db.Restaurants.Find(restaurantId);
            return contact;
        }

        public List<Restaurant> GetRestaurants()
        {
            using (HFContext database = new HFContext())
            {
                IEnumerable<Restaurant> restaurants;

                restaurants = database.Restaurants.AsEnumerable();

                return restaurants.ToList();
            }

            
        }
    }
}