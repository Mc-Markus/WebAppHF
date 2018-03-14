using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class ReservationVM
    {
        //public List<DisplayRecord> Reservation { get; set; }
        public OrderItemViewModel Order { get; set; }
        public RestaurantModel Restaurant { get; set; }

        public List<DateTime> Day { get; set; }
        public List<DateTime> Time { get; set; }

        public ReservationVM(RestaurantModel restaurant, List<DateTime> time, List<DateTime> day, OrderItemViewModel order)
        {
            //this.Reservation = records;
            this.Order = order;
            this.Restaurant = restaurant;
            this.Day = day;
            this.Time = time;
        }
        public ReservationVM() { }


    }
}