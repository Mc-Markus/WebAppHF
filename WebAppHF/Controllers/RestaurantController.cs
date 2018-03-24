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
        private readonly IRestaurantSitting _restaurantSessionRepo = new RestaurantSittingRepo();
        private readonly IRestaurantRepo _restaurantRepo = new RestaurantRepo();

        // Hardcode eventtype to give to the record eventId
        private string eventType = "RestaurantSession";

        // GET: Restaurant
        // Toon in een lijst alle restauranten
        public ActionResult Index()
        {
            List<Restaurant> restaurants = _restaurantRepo.RestaurantList();
            List<String> foods = _restaurantRepo.GetAllFoodTypes();
            var selectlistitems = foods.Select(foodType => new SelectListItem() { Value = foodType, Text = foodType });
            RestaurantIndexViewModel viewModel = new RestaurantIndexViewModel(restaurants, selectlistitems);


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(RestaurantIndexViewModel dropdown)
        {
            //RestaurantIndexViewModel test = dropdown;
            List<Restaurant> allRes = new List<Restaurant>();
            if (dropdown.RestaurantModel.FoodType1 == null)
            {
                allRes = _restaurantRepo.RestaurantList();
            }
            else
            {
                allRes = _restaurantRepo.Foodies(dropdown.RestaurantModel.FoodType1);
            }
            List<String> foods = _restaurantRepo.GetAllFoodTypes();
            var selectlistitems = foods.Select(x => new SelectListItem() { Value = x, Text = x });
            RestaurantIndexViewModel vm = new RestaurantIndexViewModel(allRes, selectlistitems);
            return View(vm);
        }

        //Toont een specifiek restaurant in de view door middel van een ID
        // Dit is de extra informatie pagina
        public ActionResult AfterDetail(int id)
        {
            // Zoekt voor een restaurant met die ID
            Restaurant restaurant = _restaurantRepo.GetRestaurant(id);
            // Restaurants die niet bestaan worden gestuurd naar de PageNotFound in de homecontroller
            if (restaurant == null)
                return RedirectToAction("PageNotFound", "Home");

            return View(restaurant);
        }

        [HttpGet]
        public ActionResult MakeReservation(int id)
        {
            // Giving the information about the restaurant
            Restaurant restaurant = _restaurantRepo.GetRestaurant(id);

            // Creating two dropdowns to pick from 
            List<DateTime> day = _restaurantRepo.GetAllDay(id);
            var dayListItem = day.Select(x => new SelectListItem() { Value = x.ToLongDateString(), Text = x.ToLongDateString() });

            // Second one is Time 
            List<DateTime> time = _restaurantRepo.GetAllTime(id);
            var timeListItem = time.Select(x => new SelectListItem() { Value = x.ToLongDateString(), Text = x.ToShortTimeString() });

            //Create new Record to use in the View
            OrderItemViewModel record = new OrderItemViewModel();

            //Passing viewmodel to the View
            ReservationVM vm = new ReservationVM(restaurant, dayListItem, timeListItem, record);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddToDataBase(ReservationVM MyTestParameter)
        {
            ReservationVM reservation = MyTestParameter;

            // Giving the record value of eventid and eventtype
            reservation.Record.Record.EventType = eventType;
            reservation.Record.Record.EventID = _restaurantSessionRepo.GetEventID(reservation.Restaurant.ID, reservation.Record.Event.Date, reservation.Record.Event.StartTime);

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

        public ActionResult testEvents()
        {
            var events = _restaurantSessionRepo.Events();
            return View(events.ToList());
        }
    }
}