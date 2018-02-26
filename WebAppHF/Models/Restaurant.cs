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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Stars { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int ReducedPrice { get; set; }
        [Required]
        public string FoodType1 { get; set; }
        [Required]
        public string FoodType2 { get; set; }
        [Required]
        public string FoodType3 { get; set; }
        [Required]
        public string FoodIMGString { get; set; }
        [Required]
        public string RestaurantIMGString { get; set; }

        public Restaurant() { }

        public Restaurant(int ID, string Name, string Address, int Stars, int Price, int ReducedPrice, string FoodType1, string FoodType2, string FoodType3, string FoodIMGString, string RestaurantIMGString)
        {
            this.ID = ID;
            this.Name = Name;
            this.Address = Address;
            this.Stars = Stars;
            this.Price = Price;
            this.ReducedPrice = ReducedPrice;
            this.FoodType1 = FoodType1;
            this.FoodType2 = FoodType2;
            this.FoodType2 = FoodType2;
            this.FoodIMGString = FoodIMGString;
            this.RestaurantIMGString = RestaurantIMGString;
        }

        //Returns the price as a formatted string
        public string GetPriceString()
        {
            double euro = Price / 100;
            return string.Format("{0:C}", euro);
        }
    }
}