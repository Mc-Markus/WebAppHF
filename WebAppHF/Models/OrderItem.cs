using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        public Event Event { get; set; }
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public int TotalPrice { get; set; }
        public string Comment { get; set; }

        //empty constructor needed for form
        public OrderItem() { }

        //constructor that should be used when adding a record to cart
        public OrderItem(Event Event)
        {
            this.Event = Event;
        }

        public void calculateTotalPrice()
        {
            if(Amount > 0 && Event != null)
            {
                this.TotalPrice = Amount * Event.Price;
            }
            else
            {
                TotalPrice = -1;
            }
        }

        //Returns the price as a formatted string
        public string GetPriceString()
        {
            double euro = TotalPrice / 100D;
            return string.Format("{0:C}", euro);
        }
    }
}