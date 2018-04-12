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
        private readonly HFContext _database = new HFContext();

        // Haalt een lijst met alle restaurants op 
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurant = _database.Restaurants.ToList();
            return restaurant;
        }
        // Haalt een restaurant op met die id 
        public Restaurant GetRestaurant(int restaurantId)
        {
            Restaurant restaurant = _database.Restaurants.Find(restaurantId);
            return restaurant;
        }
        // Creert een restaurant
        public void CreateRestaurant(Restaurant restaurant)
        {
            _database.Restaurants.Add(restaurant);
            _database.SaveChanges();
        }
        // Verwijdert een restaurant
        public void Remove(Restaurant restaurant)
        {
            _database.Restaurants.Remove(restaurant);
            _database.SaveChanges();

        }
        // Bewerkt een restaurant
        public void UpdateRestaurant(Restaurant restaurant)
        {
            _database.Entry(restaurant).State = EntityState.Modified;
            _database.SaveChanges();
        }

        // Haalt prijs op van een restaurant
        public int GetPrice(int id)
        {
            int price = _database.Restaurants.Where(m => m.ID == id)
                .Select(m => m.Price).SingleOrDefault();
            return price;
        }

        // Haalt een lijst van all restaurants op 
        public List<Restaurant> RestaurantList()
        {
            List<Restaurant> restaurant = _database.Restaurants.ToList();
            return restaurant;
        }

        // Haalt een lijst van alle foodtypes en toont geen dubbele waardes
        List<string> IRestaurantRepo.GetAllFoodTypes()
        {
            return _database.Restaurants.Select(p => p.FoodType1).Distinct().ToList();
        }

        // haalt een lijst van alle dagtijden 
        List<DateTime> IRestaurantRepo.GetAllTime(int id)
        {
            return _database.RestaurantSessions.Where(p => p.RestaurantID == id)
                .Select(p => p.StartTime).Distinct().ToList();
        }

        //Haalt een lijst van alle dagen 
        List<DateTime> IRestaurantRepo.GetAllDay(int id)
        {
            return _database.RestaurantSessions.Where(p => p.RestaurantID == id)
                .Select(p => p.Date).Distinct().ToList();
        }

        // Zoekt in elke foodtype of die waarde in voorkomt en toont dan een lijst van alle restaurants met die waarde
        public List<Restaurant> ListRestaurantFromFoodType(string foodType)
        {
            return _database.Restaurants.Where(p => p.FoodType1 == foodType || p.FoodType2 == foodType 
                                                                           || p.FoodType3 == foodType).ToList();
        }
    }
}