using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private HFContext database = new HFContext();
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurant = database.Restaurants.ToList();
            return restaurant;
        }

        public IEnumerable<Restaurant> getfoodtypes(string foodType)
        {
            var resultFoodTypes = database.Restaurants.Where(p => p.FoodTypes == foodType);
            return resultFoodTypes;
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
            // Restaurant restaurant = db.Restaurants.Where(x => x.ID == restaurantId).SingleOrDefault();
            Restaurant restaurant = database.Restaurants.Find(restaurantId);
            return restaurant;
        }
        public void CreateRestaurant(Restaurant restaurant)
        {
            database.Restaurants.Add(restaurant);
            database.SaveChanges();
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

        public void Remove(Restaurant student)
        {
            database.Restaurants.Remove(student);
            database.SaveChanges();

        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            Restaurant temp = database.Restaurants.Find(restaurant.ID);
            temp = restaurant;
            database.SaveChanges();
        }

        List<string> IRestaurantRepo.GetAllRestaurantFilter()
        {
            return database.Restaurants.Select(p => p.FoodTypes).Distinct().ToList();
        }
    }
}