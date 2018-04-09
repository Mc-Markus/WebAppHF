using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class JazzBook
    {
        public OrderItem DayPassePartout { get; set; }
        public OrderItem WeekendPassePartout { get; set; }
        public List<OrderItem> DayEvents { get; set; }

        //added this class to have all essential parts for the jazz booking page
        public JazzBook(OrderItem day, OrderItem weekend, List<OrderItem> events)
        {
            this.DayPassePartout = day;
            this.WeekendPassePartout = weekend;
            this.DayEvents = events;
        }

        public JazzBook()
        {
            
        }
    }
}