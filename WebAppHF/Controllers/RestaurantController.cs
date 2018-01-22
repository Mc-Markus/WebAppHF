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
        private IRestaurantRepo restaurantRepo = new RestaurantRepo();

        // GET: Restaurant
        // Toon in een lijst alle restauranten
        public ActionResult Index()
        {
            // Haal alle Restaurants op 
            var allRestaurants = restaurantRepo.GetAllRestaurants();
            // Haal ik alléén de foodtypes op
            var foodTypes = restaurantRepo.GetAllRestaurantFilter();
            // Creeer dropdownlist voor de view 
            List<SelectListItem> foodTypeList = new List<SelectListItem>();
            // Vullen met database waardes
            foreach (var foodTypeItem in foodTypes)
            {
                foodTypeList.Add(new SelectListItem
                {
                    Text = foodTypeItem,
                    Value = foodTypeItem
                });
            }
            // Viewbag stoppen die in de View wordt gebruikt 
            ViewBag.foodTypes = foodTypeList;
            return View(allRestaurants.ToList());
        }

        [HttpPost]
        public ActionResult Index(string foodType)
        {
            // maak het alvast vol met een lijst met alle restaurants
            var resultOfFoodType = restaurantRepo.GetAllRestaurants();
            // Als de user voor een foodtype kiest moet het de variabel een waarde hebben 
            if (foodType != "")
            {
                resultOfFoodType = restaurantRepo.getfoodtypes(foodType);
            }
            // Haal ik alléén de foodtypes op en zet het in een lijst 
            List<string> foodTypeList = restaurantRepo.GetAllRestaurantFilter();
            // Creeer dropdownlist voor de view 
            List<SelectListItem> dropdownFoodList = new List<SelectListItem>();
            // Vullen met database waardes
            foreach (var foodTypeItem in foodTypeList)
            {
                dropdownFoodList.Add(new SelectListItem
                {
                    Text = foodTypeItem,
                    Value = foodTypeItem
                });
            }
            // Viewbag stoppen die in de View wordt gebruikt 
            ViewBag.foodTypes = dropdownFoodList;
            // Geef de lijst gefilterd terug
            return View(resultOfFoodType.ToList());
            //return View();
        }



        //Toont een specifiek restaurant in de view door middel van een ID
        // Dit is de reserveringspagina
        public ActionResult Detail(int ID)
        {
            // Zoekt voor een restaurant met die ID
            Restaurant restaurant = restaurantRepo.GetRestaurant(ID);
            // Restaurants die niet bestaan worden gestuurd naar de PageNotFound in de homecontroller
            if (restaurant == null)
                return RedirectToAction("PageNotFound", "Home");
            
            return View(restaurant);
        }

        //Toont een specifiek restaurant in de view door middel van een ID
        // Dit is de extra informatie pagina
        public ActionResult AfterDetail(int ID)
        {
            // Zoekt voor een restaurant met die ID
            Restaurant restaurant = restaurantRepo.GetRestaurant(ID);
            // Restaurants die niet bestaan worden gestuurd naar de PageNotFound in de homecontroller
            if (restaurant == null)
                return RedirectToAction("PageNotFound", "Home");

            return View(restaurant);
        }
    }
}