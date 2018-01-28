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


        void CreateRestaurant(Restaurant restaurant);
        void Remove(Restaurant student);
        void UpdateRestaurant(Restaurant restaurant);
        List<string> GetAllTimeList(int id);
        List<string> GetAllDayList(int id);
        int GetPrice(int id);
    }
}