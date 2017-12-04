using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Repositories;
using WebAppHF.Models;

namespace WebAppHF.Controllers
{
    public class RestaurantController : Controller
    {
        private IResetaurantRepo repo = new RestaurantRepo();
        
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int ID)
        {
            Restaurant restaurant = repo.GetRestaurantByID(ID);

            return View(restaurant);
        }
    }
}