using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class ReservationVM
    {
        //public List<DisplayRecord> Reservation { get; set; }
        public DisplayRecord Record { get; set; }
        public Restaurant Restaurant { get; set; }

        public List<DateTime> Day { get; set; }
        public List<DateTime> Time { get; set; }

        public ReservationVM(Restaurant restaurant, List<DateTime> time, List<DateTime> day, DisplayRecord record)
        {
            //this.Reservation = records;
            this.Record = record;
            this.Restaurant = restaurant;
            this.Day = day;
            this.Time = time;
        }
        public ReservationVM() { }


    }
}