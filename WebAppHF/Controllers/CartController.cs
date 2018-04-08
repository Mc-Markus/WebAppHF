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
        public ActionResult Index()
        {
            CartModel cart = null;
            cart = (CartModel)Session["Cart"];

            if(cart == null)
            {
                RedirectToAction("CartEmpty");
            }

            return View(cart);
        }
        
        //public ActionResult PaymentMethod()
        //{
        //    //session wordt opgehaald om af te rekenen, als de prijs 0 is wordt er direct naar de success view geredirect.
        //    CartModel cart = (CartModel)Session["Cart"];
        //    if(cart.Price == 0)
        //    {
        //        return RedirectToAction("Success");
        //    }
        //    else
        //    {
        //        return View(cart);
        //    }
        //}

        [HttpPost]
        public ActionResult PaymentMethod(CartModel cart)
        {
            return RedirectToAction("Success"); 
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