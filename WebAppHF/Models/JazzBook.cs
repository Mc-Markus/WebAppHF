using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class JazzBook
    {
        public DisplayRecord DayPassePartout { get; set; }
        public DisplayRecord WeekendPassePartout { get; set; }
        public List<DisplayRecord> DayEvents { get; set; }

        public JazzBook(DisplayRecord day, DisplayRecord weekend, List<DisplayRecord> events)
        {
            this.DayPassePartout = day;
            this.WeekendPassePartout = weekend;
            this.DayEvents = events;
        }
    }

    public class TourDay
    {
         
    }
}