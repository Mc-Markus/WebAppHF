using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Models;
using WebAppHF.Repositories;

namespace WebAppHF.Controllers
{
    public class RecordsController : Controller
    {
        private IRecordRepo recordRepository = new RecordRepo();
        private IRestaurantRepo restaurantRepo = new RestaurantRepo();
        // Hardcode eventtype to give to the record eventId
        private string eventType = "RestaurantSitting";
        // GET: Records
        public ActionResult Index()
        {
            // Made a quick a view to see if the data was being passed to the database
            var listrecords = recordRepository.GetAllRestaurants();
            return View(listrecords.ToList());
        }


        //// GET: Records/Create
        //public ActionResult Create(int id)
        //{
        //    // Here is the restuarant is that the view gave 
        //    ViewBag.RestaurantID = id;

        //    // Getting all the days
        //    var day = restaurantRepo.GetAllDayList(id);

        //    // Getting all the time
        //    var time = restaurantRepo.GetAllTimeList(id);

        //    // Creating two dropdownlist 
        //    List<SelectListItem> dayList = new List<SelectListItem>();
        //    List<SelectListItem> timeList = new List<SelectListItem>();

        //    // fill it with variable day 
        //    foreach (var reservation in day)
        //    {
        //        dayList.Add(new SelectListItem
        //        {
        //            // Text will be shown as "07:30"
        //            Text = reservation.ToString("hh:mm"),
        //            Value = reservation.ToString()
        //        });
        //    }

        //    // fill it with variable time 
        //    foreach (var reservationTime in time)
        //    {
        //        timeList.Add(new SelectListItem
        //        {
        //            //Text will be showns as "thursday"
        //            Text = reservationTime.ToString("dddd"),
        //            Value = reservationTime.ToString()
        //        });
        //    }

        //    // Put list in view to use in the view 
        //    ViewBag.selectDayList = dayList;
        //    ViewBag.selecttimeList = timeList;
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,EventID,OrderID,Amount,TotalPrice,Comment")] Record record,string time, string date)
        //{
        //    // The time variables needed to find the proper SessionID
        //    DateTime recordTime;
        //    DateTime recordDate;

        //    // Controleren of de juiste waarde is meegegeven 
        //    if (time != null || time == "Choose a Time")
        //    {
        //        recordTime = Convert.ToDateTime(time);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Restaurant");
        //    }
        //    if (date != null || time == "Choose a Day")
        //    {

        //         recordDate = Convert.ToDateTime(date);
        //    } 
        //    else
        //    {
        //        return RedirectToAction("Index", "Restaurant");
        //    }

        //    // Prijs berekenen
        //    record.TotalPrice = (restaurantRepo.GetPrice(record.EventID) * record.Amount) / 100;

        //    // restaurant session id vinden
        //    record.EventID = recordRepository.GetEventID(record.EventID,recordDate, recordTime);
        //    if (record.EventID == 0)
        //    {
        //        return RedirectToAction("Index","Restaurant");
        //    }
        //    // Hardcoded eventype geven 
        //    record.EventType = eventType;

        //    // Dummy order id
        //    record.OrderID = 1;
        //    if (ModelState.IsValid)
        //    {
        //        //recordRepository.AddRecord(record);
        //        //Trying ot use a session
        //        List<Record> sessionBasket = new List<Record>();
        //        sessionBasket.Add(record);

        //        //check if session contains records if so add them to new cart value
        //        try
        //        {
        //            List<Record> basket = (List<Record>)Session["Cart"];
        //            foreach (Record sessionrecord in basket)
        //            {
        //                sessionBasket.Add(sessionrecord);
        //            }
        //        }
        //        catch
        //        {
        //            Session["Cart"] = null;
        //        }
        //        finally
        //        {
        //            Session["Cart"] = sessionBasket;
        //        }
        //        return RedirectToAction("Index","Home");
        //    }
        //    return View(record);
        //}
    }
}
