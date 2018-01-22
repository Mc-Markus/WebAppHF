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

        //added this class to have all essential parts for the jazz booking page
        public JazzBook(DisplayRecord day, DisplayRecord weekend, List<DisplayRecord> events)
        {
            this.DayPassePartout = day;
            this.WeekendPassePartout = weekend;
            this.DayEvents = events;
        }
    }
}