using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class JazzDaySummary
    {
        public string IMGString { get; set; }
        public string Day { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Bands { get; set; }

        public JazzDaySummary() { }

        public JazzDaySummary(string IMGString, string Day, DateTime Date, string Location, string Bands)
        {
            this.IMGString = IMGString;
            this.Day = Day;
            this.Date = Date;
            this.Location = Location;
            this.Bands = Bands;
        }

        public void AddBand(string band)
        {
            Bands += "; " + band;
        }
    }
}