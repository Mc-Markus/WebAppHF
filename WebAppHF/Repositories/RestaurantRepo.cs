using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class RestaurantRepo : IResetaurantRepo
    {
        public Restaurant GetRestaurantByID(int ID)
        {
            using (HFContext database = new HFContext())
            {
                Restaurant restaurant;

                restaurant = database.Restaurants.SingleOrDefault(e => e.ID == ID);

                return restaurant;
            }
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