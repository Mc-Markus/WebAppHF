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
        private IRestaurantRepo ResturantRepository = new RestaurantRepo();
        private HFContext db = new HFContext();


        // GET: Restaurant
        // Toon in een lijst alle restauranten
        public ActionResult Index()
        {
            // Haal ik alléén de foodtypes op en haal dubbele waardes eruit
            var restaurants = ResturantRepository.GetAllRestaurants();
            var query = ResturantRepository.GetAllRestaurantFilter();
            // Creeer dropdownlist voor de view 
            List<SelectListItem> foodTypeList = new List<SelectListItem>();
            // Vullen met database waardes
            foreach (var item in query)
            {
                foodTypeList.Add(new SelectListItem
                {
                    Text = item,
                    Value = item
                });
            }
            // Viewbag stoppen die in de View wordt gebruikt 
            ViewBag.foodTypes = foodTypeList;
            return View(restaurants.ToList());
        }

        [HttpPost]
        public ActionResult Index(string foodType)
        {
            List<string> query = ResturantRepository.GetAllRestaurantFilter();
            // Creeer dropdownlist voor de view 
            List<SelectListItem> foodTypeList = new List<SelectListItem>();
            // Vullen met database waardes
            foreach (var item in query)
            {
                foodTypeList.Add(new SelectListItem
                {
                    Text = item,
                    Value = item
                });
            }
            // Viewbag stoppen die in de View wordt gebruikt 
            ViewBag.foodTypes = foodTypeList;
            var sec = ResturantRepository.getfoodtypes(foodType);
            // Geef de lijst gefilterd terug
            return View(sec.ToList());
            //return View();
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