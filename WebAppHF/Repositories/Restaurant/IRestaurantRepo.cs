using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public interface IRestaurantRepo
    {
        // Get specific restaurant
        Restaurant GetRestaurant(int restaurantId);

        // Get all restaurants
        IEnumerable<Restaurant> GetAllRestaurants();

        // Get all the foodtypes
        List<string> GetAllFoodTypes();

        // return restaurants with the same foodtype
        IEnumerable<Restaurant> GetAllRestaurantsWithFoodtype(string foodtype);

        // Query to get all available time 
        List<DateTime> GetAllTime(int id);

        // Query to get all available days 
        List<DateTime> GetAllDay(int id);

        // Create a Restaurant 
        void CreateRestaurant(Restaurant restaurant);

        // Remove a Restaurant 
        void Remove(Restaurant restaurant);

        // Update a restaurant 
        void UpdateRestaurant(Restaurant restaurant);

        // Get price of a specific restaurant 
        int GetPrice(int id);
    }
}