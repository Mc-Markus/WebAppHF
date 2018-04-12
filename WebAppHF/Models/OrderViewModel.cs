using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHF.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public string Pay { get; set; }
        public IEnumerable<SelectListItem> Paymentmethods { get; set; }

        public OrderViewModel() { }

        public OrderViewModel(Order order, IEnumerable<SelectListItem> paymentMethod, string pay)
        {
            this.Paymentmethods = paymentMethod;
            this.Order = order;
            this.Pay = pay;
        }
    }
}