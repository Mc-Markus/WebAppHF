using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class Record
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public int TotalPrice { get; set; }
        public string Comment { get; set; }
        public string EventType { get; set; }

        //empty constructor needed for form
        public Record() { }

        //constructor that should be used when adding a record to cart
        public Record(int EventID, string EventType)
        {
            this.EventID = EventID;
            this.EventType = EventType;
        }
    }
}