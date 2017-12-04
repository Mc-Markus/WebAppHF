using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHF.Models
{
    public class Record
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public int TotalPrice { get; set; }
    }
}