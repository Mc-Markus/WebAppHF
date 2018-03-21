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
        //private IRecordRepository recordRepository = new RecordRepository();
        private IRestaurantSitting restaurantSessionRepo = new RestaurantSittingRepo();
        private IRestaurantRepo restaurantRepo = new RestaurantRepo();

        // Hardcode eventtype to give to the record eventId
        private string eventType = "RestaurantSitting";

        // GET: Restaurant
        // Toon in een lijst alle restauranten
        public ActionResult Index()
        {
            List<Restaurant> restaurants = restaurantRepo.RestaurantList();
            List<String> foods = restaurantRepo.GetAllFoodTypes();
            var selectlistitems = foods.Select(foodType => new SelectListItem() { Value = foodType, Text = foodType });
            RestaurantIndexViewModel vm = new RestaurantIndexViewModel(restaurants, selectlistitems);


            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(RestaurantIndexViewModel dropdown)
        {
            RestaurantIndexViewModel test = dropdown;
            List<Restaurant> allRes = restaurantRepo.Foodies(dropdown.RestaurantModel.FoodType1);
            List<String> foods = restaurantRepo.GetAllFoodTypes();
            var selectlistitems = foods.Select(x => new SelectListItem() { Value = x, Text = x });
            RestaurantIndexViewModel vm = new RestaurantIndexViewModel(allRes, selectlistitems);
            return View(vm);
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
            List<DateTime> Day = restaurantRepo.GetAllDay(id);
            //ViewBag.selectTestDayList = new SelectList(Day, "Date");
            var selectlistitems = Day.Select(x => new SelectListItem() { Value = x.ToLongDateString(), Text = x.ToLongDateString() });

            // Second one is Time 
            List<DateTime> Time = restaurantRepo.GetAllTime(id);
            //ViewBag.selectTestTimeList = new SelectList(Time, "StartTime");
            var selectlistitem2s = Time.Select(x => new SelectListItem() { Value = x.ToLongDateString(), Text = x.ToLongDateString() });

            //Create new Record to use in the View
            OrderItemViewModel record = new OrderItemViewModel();


            //Passing viewmodel to the View
            ReservationVM vm = new ReservationVM(restaurant, selectlistitems, selectlistitem2s, record);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddToDataBase(ReservationVM MyTestParameter)
        {
            ReservationVM reservation = MyTestParameter;

            // Giving the record value of eventid and eventtype
            reservation.Record.Record.EventType = eventType;
            reservation.Record.Record.EventID = restaurantSessionRepo.GetEventID(reservation.Restaurant.ID, reservation.Record.Event.StartTime, reservation.Record.Event.Date);

            List<OrderItem> sessionBasket = new List<OrderItem>();
            sessionBasket.Add(reservation.Record.Record);

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