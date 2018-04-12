using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    interface IOrderRepo
    {
        void CreateOrder(Order order);
        Order FindOrder(string email);
        void CreateOrderItem(OrderItem orderItem);
        void UpDateEvent(Event anEvent);
    }
}
