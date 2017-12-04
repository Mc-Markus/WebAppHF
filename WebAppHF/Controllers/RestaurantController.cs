using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHF.Controllers
{
    public class RestaurantController : Controller
    {
        //private RestaurantController
        
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }
    }
}