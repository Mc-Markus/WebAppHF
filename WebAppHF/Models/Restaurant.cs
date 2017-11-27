﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Stars { get; set; }
        public double Price { get; set; }
        public double ReducedPrice { get; set; }
        public string FoodTypes { get; set; }
        public string FoodIMGString { get; set; }
        public string RestaurantIMGString { get; set; }
    }
}