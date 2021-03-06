﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class Event 
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
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