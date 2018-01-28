using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public interface IRestaurantRepo
    {
        Restaurant GetRestaurant(int restaurantId);
        IEnumerable<Restaurant> GetAllRestaurants();
        List<string> GetAllRestaurantFilter();
        IEnumerable<Restaurant> getfoodtypes(string foodType);
        List<DateTime> GetAllTimeList(int id);
        List<DateTime> GetAllDayList(int id);
        int GetPrice(int id);
    }
}