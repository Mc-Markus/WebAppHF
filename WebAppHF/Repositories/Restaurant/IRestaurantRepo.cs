using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public interface IRestaurantRepo
    {
        // Get specific restaurantModel
        RestaurantModel GetRestaurant(int restaurantId);

        // Get all restaurants
        IEnumerable<RestaurantModel> GetAllRestaurants();

        // Get all the foodtypes
        List<string> GetAllFoodTypes();

        // return restaurants with the same foodtype
        IEnumerable<RestaurantModel> GetAllRestaurantsWithFoodtype(string foodtype);

        // Query to get all available time 
        List<DateTime> GetAllTime(int id);

        // Query to get all available days 
        List<DateTime> GetAllDay(int id);

        // Create a RestaurantModel 
        void CreateRestaurant(RestaurantModel restaurantModel);

        // Remove a RestaurantModel 
        void Remove(RestaurantModel restaurantModel);

        // Update a restaurantModel 
        void UpdateRestaurant(RestaurantModel restaurantModel);

        // Get price of a specific restaurantModel 
        int GetPrice(int id);

        List<RestaurantModel> RestaurantList();
    }
}