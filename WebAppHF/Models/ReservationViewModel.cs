using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHF.Models
{
    public class ReservationViewModel
    {
        public OrderItem Order { get; set; }
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Day { get; set; }
        public IEnumerable<SelectListItem> Time { get; set; }

        public ReservationViewModel(Restaurant restaurant, IEnumerable<SelectListItem> day, IEnumerable<SelectListItem> time, OrderItem orderItem)
        {
            this.Order = orderItem;
            this.Restaurant = restaurant;
            this.Day = day;
            this.Time = time;
        }
        public ReservationViewModel() { }


    }
}