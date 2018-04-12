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
        ITalkRepo rep = new TalkRepo();
        public ActionResult Index()
        {
            CartModel cart = (CartModel)Session["Cart"];

            if(cart == null)
            {
                return RedirectToAction("CartEmpty");
            }

            return View(cart);
        }

        // deze httppost index wordt checktout begin
        [HttpPost]
        public ActionResult Index(CartModel cart)
        {
            foreach(OrderItem item in cart.OrderItems)
            {
                item.Event = rep.GetTalk(item.Event.ID);
            }
            return RedirectToAction("PaymentMethod");
        }
        
        public ActionResult PaymentMethod()
        {
            //session wordt opgehaald om af te rekenen, als de prijs 0 is wordt er direct naar de success view geredirect.
            CartModel cart = (CartModel)Session["Cart"];
            int totalPrice = 0;
            foreach(OrderItem item in cart.OrderItems)
            {
                totalPrice += item.TotalPrice;
            }
            //if(totalPrice == 0)
            //{
            //    return RedirectToAction("Success");
            //}
            //else
            //{
            //    return View(cart);
            //}
            return View(cart);
        }

        [HttpPost]
        public ActionResult PaymentMethod(CartModel cart)
        {
            return RedirectToAction("Success"); 
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult AddedTeoCart()
        {
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
            List<String> allPayments = new List<string>();
            
            allPayments.Add("IDeal");
            allPayments.Add("Visa");
            allPayments.Add("MasterCard");
            allPayments.Add("PayPal");
            var selectlistitems = allPayments.Select(payment =>
                new SelectListItem() {Value = allPayments[0], Text = allPayments[0]});

            for (int i = 0; i < allPayments.Count; i++)
            {
                selectlistitems = allPayments.Select(payment => new SelectListItem() { Value = allPayments[i], Text = allPayments[i] });
            }

            Order order = new Order(); 
            OrderViewModel viewModel = new OrderViewModel(order, selectlistitems,"");
            return View(viewModel);
        } 
    }
}