using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models.Restaurant
{
    public class IndexViewModel
    {
        public List<RestaurantModel> Restaurants { get; set; }
        public List<String> foodtypes { get; set; }

    }
}