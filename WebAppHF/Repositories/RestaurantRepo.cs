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
            using (Database database = new Database())
            {
                Restaurant restaurant;

                restaurant = database.Restaurants.SingleOrDefault(e => e.ID == ID);

                return restaurant;
            }
        }
    }
}