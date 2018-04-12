using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public int getOrderIdByEmail(string email)
        {
            Order order;

            try
            {
                order = ctx.Orders.Where(x => x.Email == email).SingleOrDefault();
            }
            catch
            {
                return 0;
            }

            return order.ID;
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            ctx.Records.Add(orderItem);
            ctx.SaveChanges();
        }

        public void UpDateEvent(Event anEvent)
        {
            ctx.Entry(anEvent).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}