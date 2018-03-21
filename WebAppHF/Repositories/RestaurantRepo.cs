using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAppHF.Models;
using System.Data.Entity;

namespace WebAppHF.Repositories
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private HFContext database = new HFContext();

        public List<DateTime> GetAllDayList(int id)
        {
            return database.RestaurantSessions.Where(p => p.RestaurantID == id && p.SeatsAvailable > 0).Select(p => p.StartTime).Distinct().ToList();
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurant = database.Restaurants.ToList();
            return restaurant;
        }

        public List<DateTime> GetAllTimeList(int id)
        {
            return database.RestaurantSessions.Where(p => p.RestaurantID == id && p.SeatsAvailable > 0).Select(p => p.Date).Distinct().ToList();
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
        public void Remove(Restaurant restaurant)
        {
            database.Restaurants.Remove(restaurant);
            database.SaveChanges();

        }
        public void UpdateRestaurant(Restaurant restaurant)
        {
            database.Entry(restaurant).State = EntityState.Modified;
            database.SaveChanges();
        }
        public int GetPrice(int id)
        {
            int price = database.Restaurants.Where(m => m.ID == id).Select(m => m.Price).SingleOrDefault();
            return price;
        }
        public List<Restaurant> RestaurantList()
        {
            List<Restaurant> restaurant = database.Restaurants.ToList();
            return restaurant;
        }

        List<string> IRestaurantRepo.GetAllFoodTypes()
        {
            return database.Restaurants.Select(p => p.FoodType1).Distinct().ToList();
        }

        List<DateTime> IRestaurantRepo.GetAllTime(int id)
        {
            return database.RestaurantSessions.Select(p => p.StartTime).Distinct().ToList();
        }

        List<DateTime> IRestaurantRepo.GetAllDay(int id)
        {
            return database.RestaurantSessions.Select(p => p.Date).Distinct().ToList();
        }

        public List<Restaurant> Foodies(string foodType)
        {
            return database.Restaurants.Where(p => p.FoodType1 == foodType || p.FoodType2 == foodType || p.FoodType3 == foodType).ToList();

        }
    }
}