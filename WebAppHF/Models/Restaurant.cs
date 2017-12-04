using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppHF.Models
{
    public class Restaurant
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Stars { get; set; }
        public int Price { get; set; }
        public int ReducedPrice { get; set; }
        public string FoodTypes { get; set; }
        public string FoodIMGString { get; set; }
        public string RestaurantIMGString { get; set; }

        public Restaurant() { }

        public Restaurant(int ID, string Name, string Address, int Stars, int Price, int ReducedPrice, string FoodTypes, string FoodIMGString, string RestaurantIMGString)
        {
            this.ID = ID;
            this.Name = Name;
            this.Address = Address;
            this.Stars = Stars;
            this.Price = Price;
            this.ReducedPrice = ReducedPrice;
            this.FoodTypes = FoodTypes;
            this.FoodIMGString = FoodIMGString;
            this.RestaurantIMGString = RestaurantIMGString;
        }
    }
}