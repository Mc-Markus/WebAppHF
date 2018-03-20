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
        public IEnumerable<SelectListItem> foodtypes { get; set; }

        public RestaurantIndexViewModel(List<Restaurant> Restaurants, IEnumerable<SelectListItem> fooodies)
        {
            this.Restaurants = Restaurants;
            this.foodtypes = fooodies;
        }

        public RestaurantIndexViewModel() { }
    }
}