using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public abstract class Event 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string LocationName { get; set; }
        public int Price { get; set; }
        public string Adress { get; set; }
        public int SeatsAvailable { get; set; }

        //Returns the price as a formatted string
        public string GetPriceString()
        {
            double euro = Price / 100D;
            return string.Format("{0:C}", euro);
        }
    }
}