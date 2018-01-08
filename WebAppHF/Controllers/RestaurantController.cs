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
        // Maak instantie van de interface om niet direct met je database te praten
        private IResetaurantRepo ResturantRepository = new RestaurantRepo();
        
        // GET: Restaurant
        // Toon in een lijst alle restauranten
        public ActionResult Index()
        {

            var restaurant = ResturantRepository.GetAllRestaurants();
            return View(restaurant.ToList());
        }

        //Toont een specifiek restaurant in de view door middel van een ID
        public ActionResult Detail(int ID)
        {
            Restaurant restaurant = ResturantRepository.GetRestaurant(ID);
            return View(restaurant);
        }

        //Toont een specifiek restaurant in de view door middel van een ID
        public ActionResult AfterDetail(int id)
        {
            Restaurant restaurant = ResturantRepository.GetRestaurant(id);
            return View(restaurant);
        }
    }
}