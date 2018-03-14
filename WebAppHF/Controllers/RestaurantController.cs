using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using WebAppHF.Repositories;
using WebAppHF.Models;

namespace WebAppHF.Controllers
{
    public class RestaurantController : Controller
    {
        // Maak instantie van de interface om niet direct met je database te praten
        //private IRecordRepository recordRepository = new RecordRepository();
        private IRestaurantSitting restaurantSessionRepo = new RestaurantSittingRepo();
        private IRestaurantRepo restaurantRepo = new RestaurantRepo();

        // Hardcode eventtype to give to the record eventId
        private string eventType = "RestaurantSitting";

        // GET: RestaurantModel
        // Toon in een lijst alle restauranten
        public ActionResult TestIndex()
        {
            List<RestaurantModel> restaurants = new List<RestaurantModel>();
            restaurants = restaurantRepo.RestaurantList();

            return View(restaurants.ToList());
        }
        public ActionResult Index()
        {
            // Haal alle Restaurants op 
            var allRestaurants = restaurantRepo.GetAllRestaurants();
            // Haal ik alle foodtypes op 
            var allFoodTypes = restaurantRepo.GetAllFoodTypes();
            // Creeer dropdownlist voor de view 
            List<SelectListItem> foodTypeList = new List<SelectListItem>();
            // Vullen met database waardes
            foreach (var foodTypeItem in allFoodTypes)
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
            var allRestaurantsWithFoodType = restaurantRepo.GetAllRestaurants();
            // Als de user voor een foodtype kiest moet het de variabel een waarde hebben 
            if (foodType != "")
            {
                allRestaurantsWithFoodType = restaurantRepo.GetAllRestaurantsWithFoodtype(foodType);
            }
            // Haal ik alle foodtypes op 
            var allFoodTypes = restaurantRepo.GetAllFoodTypes();
            // Creeer dropdownlist voor de view 
            List<SelectListItem> foodTypeList = new List<SelectListItem>();
            // Vullen met database waardes
            foreach (var foodTypeItem in allFoodTypes)
            {
                foodTypeList.Add(new SelectListItem
                {
                    Text = foodTypeItem,
                    Value = foodTypeItem
                });
            }
            // Viewbag stoppen die in de View wordt gebruikt 
            ViewBag.foodTypes = foodTypeList;
            // Geef de lijst gefilterd terug
            return View(allRestaurantsWithFoodType.ToList());
            //return View();
        }

        //Toont een specifiek restaurant in de view door middel van een id
        // Dit is de extra informatie pagina
        public ActionResult AfterDetail(int id)
        {
            // Zoekt voor een restaurantModel met die id
            RestaurantModel restaurantModel = restaurantRepo.GetRestaurant(id);
            // Restaurants die niet bestaan worden gestuurd naar de PageNotFound in de homecontroller
            if (restaurantModel == null)
                return RedirectToAction("PageNotFound", "Home");

            return View(restaurantModel);
        }

        [HttpGet]
        public ActionResult MakeReservation(int id)
        {
            // Giving the information about the restaurantModel
            RestaurantModel restaurantModel =  restaurantRepo.GetRestaurant(id);


            // Creating two dropdowns to pick from 
            // First one is Day
            List<DateTime> Day = restaurantRepo.GetAllDay(id);
            ViewBag.selectTestDayList = new SelectList(Day, "Date");

            // Second one is Time 
            List<DateTime> Time = restaurantRepo.GetAllTime(id);
            ViewBag.selectTestTimeList = new SelectList(Time, "StartTime");

            //Create new Order to use in the View
            OrderItemViewModel record = new OrderItemViewModel();


            //Passing viewmodel to the View
            ReservationVM vm = new ReservationVM(restaurantModel, Day, Time, record);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddToDataBase(ReservationVM createReservation)
        {
            ReservationVM reservation = createReservation;

            // Giving the record value of eventid and eventtype
            reservation.Order.Record.EventType = eventType;
            reservation.Order.Record.EventID = restaurantSessionRepo.GetEventID(reservation.Restaurant.ID, reservation.Order.Event.StartTime, reservation.Order.Event.Date);

            List<OrderItem> sessionBasket = new List<OrderItem>();
            sessionBasket.Add(reservation.Order.Record);

            //check if session contains records if so add them to new cart value
            try
            {
                List<OrderItem> basket = (List<OrderItem>)Session["Cart"];
                foreach (OrderItem sessionrecord in basket)
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