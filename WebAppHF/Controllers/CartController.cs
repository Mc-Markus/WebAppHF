using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Models;

namespace WebAppHF.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            CartModel cart = (CartModel)Session["Cart"];
            return View(cart);
        }

        [HttpPost]
        public ActionResult Index(CartModel cart)
        {
            //insert

            //Redirect success/failure page
            return View();
        }
    }
}