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
        private IRecordRepository recordRepository = new RecordRepository();
        private IRestaurantRepo restaurantRepo = new RestaurantRepo();

        // Hardcode eventtype to give to the record eventId
        private string eventType = "RestaurantSession";

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

        [HttpGet]
        public ActionResult MakeReservation(int id)
        {
            // Giving the information about the restaurant
            Restaurant restaurant = new Restaurant();
            restaurant = restaurantRepo.GetRestaurant(id);

            // Creating two dropdowns to pick from 
            // First one is Day
            List<DateTime> Day = restaurantRepo.GetAllDayList(id);
            ViewBag.selectTestDayList = new SelectList(Day, "Date");

            // Second one is Time 
            List<DateTime> Time = restaurantRepo.GetAllTimeList(id);
            ViewBag.selectTestTimeList = new SelectList(Time, "StartTime");

            //Create new Record to use in the View
            DisplayRecord record = new DisplayRecord();


            //Passing viewmodel to the View
            ReservationVM vm = new ReservationVM(restaurant, Day, Time, record);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddToDataBase(ReservationVM MyTestParameter)
        {
            ReservationVM reservation = MyTestParameter;

            // Giving the record value of eventid and eventtype
            reservation.Record.Record.EventType = eventType;
            reservation.Record.Record.EventID = recordRepository.GetEventID(reservation.Restaurant.ID, reservation.Record.Event.StartTime, reservation.Record.Event.Date);

            List<Record> sessionBasket = new List<Record>();
            sessionBasket.Add(reservation.Record.Record);

            //check if session contains records if so add them to new cart value
            try
            {
                List<Record> basket = (List<Record>)Session["Cart"];
                foreach (Record sessionrecord in basket)
                {
                    sessionBasket.Add(sessionrecord);
                }
            }
            catch
            {
                Session["Cart"] = null;
            }
            finally
            {
                Session["Cart"] = sessionBasket;
            }

            //send user to basket after things are added to basket
            return RedirectToAction("Index", "Cart");
        }
    }
}