using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Repositories;

namespace WebAppHF.Models
{
    public class DisplayRecord
    {
        public Event Event { get; set; }
        public Record Record { get; set; }

        //added this class to easaly get to the properties of both the event and the record
        //used in cart and jazz
        public DisplayRecord(Event activity, Record record)
        {
            this.Event = activity;
            this.Record = record;
        }

        public DisplayRecord() { }
    }
}