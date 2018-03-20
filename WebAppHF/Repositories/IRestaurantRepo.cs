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

        void CreateRestaurant(Restaurant restaurant);
        void Remove(Restaurant student);
        void UpdateRestaurant(Restaurant restaurant);

        int GetPrice(int id);
        List<Restaurant> RestaurantList();
        List<Restaurant> Foodies(string foodtype);
        List<string> GetAllFoodTypes();
    }
}