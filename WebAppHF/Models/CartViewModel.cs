using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class CartViewModel
    {
        public List<OrderItemViewModel> displayRecords;
        public List<Restaurant> restaurants;

        public CartViewModel(List<OrderItemViewModel> displayRecords, List<Restaurant> restaurants)
        {
            this.displayRecords = displayRecords;
            this.restaurants = restaurants;
        }
    }
}