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
        private IRecordRepository recordRepository = new RecordRepository();
        private IRestaurantRepo restaurantRepo = new RestaurantRepo();
        // GET: Records
        public ActionResult Index()
        {
            var listrecords = recordRepository.GetAllRestaurants();
            return View(listrecords.ToList());
        }


        // GET: Records/Create
        public ActionResult Create(int id)
        {
            ViewBag.RestaurantID = id;
            var day = restaurantRepo.GetAllDayList(id);
            var time = restaurantRepo.GetAllTimeList(id);
            List<SelectListItem> dayList = new List<SelectListItem>();
            List<SelectListItem> timeList = new List<SelectListItem>();
            foreach (var reservation in day)
            {
                dayList.Add(new SelectListItem
                {
                    Text = reservation,
                    Value = reservation
                });
            }
            foreach (var reservationTime in time)
            {
                timeList.Add(new SelectListItem
                {
                    Text = reservationTime,
                    Value = reservationTime
                });
            }
            ViewBag.selectDayList = dayList;
            ViewBag.selecttimeList = timeList;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EventID,OrderID,Amount,TotalPrice,Comment")] Record record,string time, string date)
        {
            record.TotalPrice = restaurantRepo.GetPrice(record.EventID);
            record.EventID = recordRepository.GetEventID(record.EventID,
                DateTime.ParseExact(date, "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture), 
                DateTime.ParseExact(time, "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture));
            record.OrderID = 1;
            if (ModelState.IsValid)
            {
                recordRepository.AddRecord(record);
                return RedirectToAction("Index");
            }
            return View(record);
        }
    }
}
