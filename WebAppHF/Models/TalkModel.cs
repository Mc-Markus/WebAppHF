using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class TalkModel : Event
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxTicketsPP { get; set; }
        public string Hall { get; set; }
        public string IMGString { get; set; }
        public int Amount { get; set; }

        public TalkModel(Talk talk)
        {
            this.Adress = talk.Adress;
            this.Date = talk.Date;
            this.Description = talk.Description;
            this.EndTime = talk.EndTime;
            this.Hall = talk.Hall;
            this.ID = talk.ID;
            this.IMGString = talk.IMGString;
            this.LocationName = talk.LocationName;
            this.MaxTicketsPP = talk.MaxTicketsPP;
            this.Name = talk.Name;
            this.Price = talk.Price;
            this.SeatsAvailable = talk.SeatsAvailable;
            this.StartTime = talk.StartTime;
            this.Title = talk.Title;
        }

        public TalkModel() { }
    }
}