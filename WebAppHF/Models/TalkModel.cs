using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class TalkModel : Event
    {
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public int MaxTicketsPP { get; set; }
        //public string Hall { get; set; }
        //public string IMGString { get; set; }
        public Talk Talk { get; set; }
        public int Amount { get; set; }

        public TalkModel(Talk talk)
        {
            this.Talk = talk;
        }

        public TalkModel() { }
    }
}