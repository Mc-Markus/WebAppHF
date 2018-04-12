using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Models;
using WebAppHF.Repositories;

namespace WebAppHF.Controllers
{

    public class CartController : Controller
    {
        // GET: Cart
        private readonly IOrderRepo _orderRepo = new OrderRepo();
        ITalkRepo rep = new TalkRepo();
        public ActionResult Index()
        {
            CartModel cart = (CartModel)Session["Cart"];

            if(cart == null || cart.OrderItems.Count == 0)
            {
                return RedirectToAction("CartEmpty");
            }

            return View(cart);
        }

        // deze httppost index wordt checktout begin
        [HttpPost]
        public ActionResult Index(CartModel cart)
        {
            foreach (OrderItem item in cart.OrderItems)
            {
                item.Event = rep.GetTalk(item.Event.ID);
            }
            return RedirectToAction("PaymentMethod");
        }
        // niet meer in gebruik
        //public ActionResult PaymentMethod()
        //{
        //    //session wordt opgehaald om af te rekenen, als de prijs 0 is wordt er direct naar de success view geredirect.
        //    CartModel cart = (CartModel)Session["Cart"];
        //    int totalPrice = 0;
        //    foreach(OrderItem item in cart.OrderItems)
        //    {
        //        totalPrice += item.TotalPrice;
        //    }
        //    //if(totalPrice == 0)
        //    //{
        //    //    return RedirectToAction("Success");
        //    //}
        //    //else
        //    //{
        //    //    return View(cart);
        //    //}
        //    return View(cart);
        //}

        public ActionResult RemoveFromCart(int id)
        {
            CartModel cart = (CartModel)Session["Cart"];
            OrderItem dummy = new OrderItem();
            foreach (OrderItem item in cart.OrderItems)
            {
                if (item.Event.ID == id)
                {
                    dummy = item;
                }
            }
            cart.OrderItems.Remove(dummy);
            Session["Cart"] = cart;
            return RedirectToAction("Index");
        }
        // niet meer in gebruik
        //[HttpPost]
        //public ActionResult PaymentMethod(CartModel cart)
        //{
        //    return RedirectToAction("Success"); 
        //}

        public ActionResult Success()
        {
            if((CartModel)Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult CartEmpty()
        {
            return View();
        }

        public ActionResult Failure()
        {
            return View();
        }

        public ActionResult CreateOrder()
        {
            // Looking in the session for a cart 
            CartModel cart = (CartModel)Session["Cart"];
            if (cart == null)
            {
                return RedirectToAction("CartEmpty");
            }

            // create list for payment methods
            List<String> allPayments = new List<string>();

            allPayments.Add("IDeal");
            var selectlistitems = allPayments.Select(payment =>
                new SelectListItem() { Value = allPayments[0], Text = allPayments[0] });

            // Creating order for in the viewmodel
            Order order = new Order();
            // Passing the data in the viewmodel
            OrderViewModel viewModel = new OrderViewModel(order, selectlistitems, "");
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddToDatabase(OrderViewModel formResponse)
        {
            // variabel for seats
            int seats = 0;

            // Looking for session in cart
            CartModel cart = (CartModel)Session["Cart"];
            if (cart == null)
            {
                return RedirectToAction("CartEmpty");
            }

            // Put data from form into Order class
            Order orderFromForm = formResponse.Order;

            // find existing order
            Order existingOrder = _orderRepo.FindOrder(formResponse.Order.Email);
            // If there is no order, there will be one created with the information
            if (existingOrder == null)
            {
                // Creating Account Order
                _orderRepo.CreateOrder(orderFromForm);
                // Now that an id had been created for order, the id can be passed into orderitem.
                orderFromForm = _orderRepo.FindOrder(formResponse.Order.Email);
                for (int i = 0; i < cart.OrderItems.Count; i++)
                {
                    // Giving OrderItem a Orderid from the form
                    cart.OrderItems[i].OrderID = orderFromForm.ID;

                    // Creating a new Order Item
                    _orderRepo.CreateOrderItem(cart.OrderItems[i]);

                    // Changing the amount of seats 
                    seats = cart.OrderItems[i].Event.SeatsAvailable - cart.OrderItems[i].Amount;

                    //Assign value to event
                    cart.OrderItems[i].Event.SeatsAvailable = seats;

                    // Update in the database
                    _orderRepo.UpDateEvent(cart.OrderItems[i].Event);


                }
            }
            // passing the order id in the orderitem and creating database record
            else
            {
                // In this case there already is a AccountOrder
                for (int i = 0; i < cart.OrderItems.Count; i++)
                {
                    // Giving OrderItem a Orderid from the form
                    cart.OrderItems[i].OrderID = existingOrder.ID;

                    // Creating a new Order Item
                    _orderRepo.CreateOrderItem(cart.OrderItems[i]);

                    // cart.OrderItems[i].Event.ID = 

                    // Changing the amount of seats 
                    seats = cart.OrderItems[i].Event.SeatsAvailable - cart.OrderItems[i].Amount;

                    //Assign value to event
                    cart.OrderItems[i].Event.SeatsAvailable = seats;

                    // Update in the database
                    _orderRepo.UpDateEvent(cart.OrderItems[i].Event);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}