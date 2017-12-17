using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public interface IResetaurantRepo
    {
        Restaurant GetRestaurant(int restaurantId);
        IEnumerable<Restaurant> GetAllRestaurants();

        Restaurant CreateRestaurant(Restaurant restaurant);
        void Remove(Restaurant student);
    }
}