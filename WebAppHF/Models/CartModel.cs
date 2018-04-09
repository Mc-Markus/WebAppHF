using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppHF.Enums;

namespace WebAppHF.Models
{
    public class CartModel
    {
        public List<OrderItem> orderItems { get; set; }
        public List<Event> crossSellingEvents { get; set; } 

        public CartModel()
        {
            orderItems = new List<OrderItem>();
            crossSellingEvents = new List<Event>();
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            orderItem.calculateTotalPrice();
            orderItems.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            orderItems.Remove(orderItem);
        }
    }
}