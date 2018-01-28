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
        IEventRepo rep = new EventRepo();
        // GET: Cart
        public ActionResult Index()
        {
            Random rng = new Random();
            CartModel cart = new CartModel();
            cart.Items = (List<Event>)Session["cart"];
            if (cart.Items == null)
            {
                return RedirectToAction("CartEmpty");
            }
            List<Event> list = rep.GetEvents();
            cart.Items = list;

            List<Event> cross = new List<Event>();
            int i = 0;

            while (i != 5)
            {
                cross.Add(list[rng.Next(0, (list.Count - 1))]);
                i++;
            }
            cart.CrossSellItems = cross;
            return View(cart);
        }

        [HttpPost]
        public ActionResult Index(CartModel cart)
        {
            return View();
        }

        public ActionResult PaymentMethod()
        {
            CartModel cart = new CartModel();
            cart.Items = (List<Event>)Session["cart"];
            foreach(Event e in cart.Items)
            {
                cart.Price += e.Price;
            }
            return View(cart);
        }

        [HttpPost]
        public ActionResult PaymentMethod(CartModel cart)
        {
            // gooi shit in db
            return RedirectToAction("Success"); // of failure
        }

        public ActionResult Success()
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
    }
}