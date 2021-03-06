﻿using System;
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

        // GET: Restaurant
        // Toon in een lijst alle restauranten
        public ActionResult Index()
        {
            // stopt een lijst van alle restaurants
            List<Restaurant> restaurants = _restaurantRepo.RestaurantList();

            // stopt een lijst met cuisine voor in de filter
            List<String> allFoodTypes = _restaurantRepo.GetAllFoodTypes();

            // vullen de lijst met foodtpe waarde
            var selectlistitems = allFoodTypes.Select(foodType => new SelectListItem() { Value = foodType, Text = foodType });

            if (restaurants == null || allFoodTypes == null || selectlistitems == null) 
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            // stopt alle models in de viewemodel
            RestaurantIndexViewModel viewModel = new RestaurantIndexViewModel(restaurants, selectlistitems);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(RestaurantIndexViewModel dropdown)
        {
            // Creer lijst
            List<Restaurant> allRes;

            // Bekijk of de dropdown lijst leeg is of vol 
            if (dropdown.RestaurantModel.FoodType1 == null)
            {
                // Stop lijst met alle restaurants, is het geval als de user klikt op all Categories
                allRes = _restaurantRepo.RestaurantList();
            }
            else
            {
                // stopt een lijst met alle restaurants met de cuisine die gekozen is
                allRes = _restaurantRepo.ListRestaurantFromFoodType(dropdown.RestaurantModel.FoodType1);
            }
            // Creeer een filter weer als de user weer wil gaan fiteren 
            List<String> allFoodTypes = _restaurantRepo.GetAllFoodTypes();
            var selectlistitems = allFoodTypes.Select(x => new SelectListItem() { Value = x, Text = x });

            if (allRes == null || allFoodTypes == null || selectlistitems == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
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
        public ActionResult Book(int id)
        {
            // Giving the information about the restaurant
            Restaurant restaurant = _restaurantRepo.GetRestaurant(id);

            if (restaurant == null)
                return RedirectToAction("PageNotFound", "Home");

            // Creating two dropdowns to pick from 
            List<DateTime> day = _restaurantRepo.GetAllDay(id);
            var dayListItem = day.Select(x => new SelectListItem() { Value = x.ToLongDateString(), Text = x.ToLongDateString() });

            // Second one is Time 
            List<DateTime> time = _restaurantRepo.GetAllTime(id);
            var timeListItem = time.Select(x => new SelectListItem() { Value = x.ToString(), Text = x.ToShortTimeString() });

            //Create new Record to use in the View
            OrderItem order = new OrderItem();

            //Passing viewmodel to the View
            ReservationViewModel viewModel = new ReservationViewModel(restaurant, dayListItem, timeListItem, order);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddToSession(ReservationViewModel FormResponse)
        {
            // Vult de model met de data
            ReservationViewModel reservation = FormResponse;
            // zoekt de juiste event dat daarbij hoort
            reservation.Order.Event = _restaurantSessionRepo.GetEvent(reservation.Restaurant.ID, reservation.Order.Event.Date, reservation.Order.Event.StartTime);
            // kijken of er een event gevonden is
            if (reservation.Order.Event == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            //maak een lege cart
            CartModel cart;

            //als cart in de session leeg is maak een nieuwe
            if ((CartModel)Session["Cart"] == null)
            {
                cart = new CartModel();
            }
            //anders stop de inhoud van de session in de cart
            else
            {
                cart = (CartModel)Session["Cart"];
            }
            // de event toevoegen aan de session
            cart.AddOrderItem(reservation.Order);
            Session["Cart"] = cart;
            return RedirectToAction("Index", "Cart");
        }
    }
}