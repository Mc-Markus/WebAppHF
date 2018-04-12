using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class OrderItemRepo : IOrderItemRepo
    {
        public List<OrderItem> getOrderItemsByOrderID(int id)
        {
            IEnumerable<OrderItem> orderItems;
            using (HFContext context = new HFContext())
            {
                orderItems = context.OrderItems.Where(o => o.OrderID == id);

                return orderItems.ToList();
            }
        }
    }
}