using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class JazzBook
    {
        public OrderItemViewModel DayPassePartout { get; set; }
        public OrderItemViewModel WeekendPassePartout { get; set; }
        public List<OrderItemViewModel> DayEvents { get; set; }

        //added this class to have all essential parts for the jazz booking page
        public JazzBook(OrderItemViewModel day, OrderItemViewModel weekend, List<OrderItemViewModel> events)
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