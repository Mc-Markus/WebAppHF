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
        public double Price { get; set; }
        public string Adress { get; set; }
        public int SeatsAvailable { get; set; }


    }
}