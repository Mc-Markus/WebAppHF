using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHF.Models
{
    public class RestaurantIndexViewModel
    {
        public List<Restaurant> Restaurants { get; set; }
        public Restaurant RestaurantModel { get; set; }
        public IEnumerable<SelectListItem> Foodtypes { get; set; }

        public RestaurantIndexViewModel(List<Restaurant> restaurants, IEnumerable<SelectListItem> dropdownlistFoodTypes)
        {
            this.Restaurants = restaurants;
            this.Foodtypes = dropdownlistFoodTypes;
        }

        public RestaurantIndexViewModel() { }
    }
}