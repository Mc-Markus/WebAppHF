﻿using System;
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

        public List<DateTime> GetAllDay(int id)
        {
            return database.RestaurantSessions.Where(p => p.RestaurantID == id && p.SeatsAvailable > 0).Select(p => p.StartTime).Distinct().ToList();
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurant = database.Restaurants.ToList();
            return restaurant;
        }

        public List<DateTime> GetAllTime(int id)
        {
            return database.RestaurantSessions.Where(p => p.RestaurantID == id && p.SeatsAvailable > 0).Select(p => p.Date).Distinct().ToList();
        }

        public IEnumerable<Restaurant> GetAllRestaurantsWithFoodtype(string foodType)
        {
            var resultFoodTypes = database.Restaurants.Where(p => p.FoodType1 == foodType || p.FoodType2 == foodType || p.FoodType3 == foodType);
            return resultFoodTypes;
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
            Restaurant restaurantModel = database.Restaurants.Find(restaurantId);
            return restaurantModel;
        }
        public void CreateRestaurant(Restaurant restaurantModel)
        {
            database.Restaurants.Add(restaurantModel);
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




        public void Remove(Restaurant restaurantModel)
        {
            database.Restaurants.Remove(restaurantModel);
            database.SaveChanges();

        }

        public void UpdateRestaurant(Restaurant restaurantModel)
        {
            database.Entry(restaurantModel).State = EntityState.Modified;
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
    }
}