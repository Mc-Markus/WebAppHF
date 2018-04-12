using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Enums;

namespace WebAppHF.Models
{
    public class CartModel
    {
        public List<OrderItem> OrderItems { get; set; }
        public List<Event> CrossSellingEvents { get; set; } 

        public CartModel()
        {
            OrderItems = new List<OrderItem>();
            CrossSellingEvents = new List<Event>();
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            orderItem.calculateTotalPrice();
            OrderItems.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            OrderItems.Remove(orderItem);
        }
    }
}