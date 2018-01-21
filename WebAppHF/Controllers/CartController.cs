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
            //CartModel cart = (CartModel)Session["Cart"];
            CartModel cart = new CartModel();
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
            //insert db
            //rep.addorder(cart someshit info etc), check in rep voor exceptions, handel hier af

            //Redirect success/failure page
            return View();
        }

        public ActionResult PaymentMethod()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Failure()
        {
            return View();
        }
    }
}