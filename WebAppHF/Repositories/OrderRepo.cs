using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        HFContext ctx = new HFContext();
        public void CreateOrder(Order order)
        {
            ctx.Orders.Add(order);
            ctx.SaveChanges();
        }

        public Order FindOrder(string email)
        {
            Order order = ctx.Orders.Where(x => x.Email == email).SingleOrDefault();
            return order;
        }
    }
}