using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class Talk : Event
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxTicketsPP { get; set; }
        public string Hall { get; set; }
        public string IMGString { get; set; }

    }
}