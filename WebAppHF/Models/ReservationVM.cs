using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHF.Models
{
    public class ReservationVM
    {
        public OrderItemViewModel Record { get; set; }
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Day { get; set; }
        public IEnumerable<SelectListItem> Time { get; set; }

        public ReservationVM(Restaurant restaurant, IEnumerable<SelectListItem> day, IEnumerable<SelectListItem> time, OrderItemViewModel record)
        {
            this.Record = record;
            this.Restaurant = restaurant;
            this.Day = day;
            this.Time = time;
        }
        public ReservationVM() { }


    }
}