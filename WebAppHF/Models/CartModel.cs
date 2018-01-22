using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Enums;

namespace WebAppHF.Models
{
    public class CartModel
    {
        public List<Event> Items { get; set; }
        public List<Event> CrossSellItems { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int Price { get; set; }
    }
}