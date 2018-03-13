using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class CartViewModel
    {
        public List<OrderItemViewModel> displayRecords;
        public List<RestaurantModel> restaurants;

        public CartViewModel(List<OrderItemViewModel> displayRecords, List<RestaurantModel> restaurants)
        {
            this.displayRecords = displayRecords;
            this.restaurants = restaurants;
        }
    }
}