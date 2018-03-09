using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Models;
using WebAppHF.Repositories;

namespace WebAppHF.Controllers
{
    public class JazzController : Controller
    {

        private IJazzRepo repo = new JazzRepo();
        private string eventType = "Jazz";
        // GET: Jazz
        public ActionResult Index()
        {
            //gets a list with summarys for every day of the festival
            List<JazzDaySummary> summarys = repo.GetDaySummarys();

            if (summarys == null)
            {
                return RedirectToAction("Index", "HomeController", null);
            }

            return View(summarys);
        }

        public ActionResult Day(DateTime date)
        {
            //gets all jazz events for a single day
            List<Jazz> JazzActs = repo.GetJazzActsByDay(date);

            if (JazzActs == null)
            {
                return RedirectToAction("Index");
            }
            return View(JazzActs);
        }

        [HttpGet]
        public ActionResult Book(DateTime date)
        {
            //gets all jazz tickets for an event
            List<Jazz> JazzActs = repo.GetJazzActsByDay(date);
            Jazz passePartoutWeekend = repo.GetPassePartoutWeekend();
            Jazz passePartoutDay = repo.GetPassePartoutDay(date);

            //converts jazz's into displayrecords
            OrderItemViewModel displayRecordWeekend = new OrderItemViewModel(passePartoutWeekend, new OrderItem(passePartoutWeekend.ID, eventType));
            OrderItemViewModel displayRecordDay = new OrderItemViewModel(passePartoutDay, new OrderItem(passePartoutDay.ID, eventType));
            List<OrderItemViewModel> displayRecordEvents = new List<OrderItemViewModel>();

            foreach (Jazz jazz in JazzActs)
            {
                OrderItemViewModel dr = new OrderItemViewModel(jazz, new OrderItem(jazz.ID, eventType));
                displayRecordEvents.Add(dr);
            }

            JazzBook jazzBook = new JazzBook(displayRecordDay, displayRecordWeekend, displayRecordEvents);

            //string hall = ((Jazz)dr.Event).Hall;
            return View(jazzBook);

        }

        [HttpPost]
        public ActionResult AddToSession(JazzBook MyTestParameter)
        {
            //parameter could possably be changed but i leave it here cause of problems in the past
            JazzBook book = MyTestParameter;


            List<OrderItem> sessionBasket = new List<OrderItem>();
            //adds the passe-partouts if they are selected by customer
            if (book.DayPassePartout.Record.Amount > 0)
            {
                sessionBasket.Add(book.DayPassePartout.Record);
            }
            if (book.WeekendPassePartout.Record.Amount > 0)
            {
                sessionBasket.Add(book.WeekendPassePartout.Record);
            }

            //adds other jazz's if selected by customer
            foreach (OrderItemViewModel dr in book.DayEvents)
            {
                if (dr.Record.Amount > 0)
                {
                    sessionBasket.Add(dr.Record);
                }
            }

            //check if session contains records if so add them to new cart value
            try
            {
                List<OrderItem> basket = (List<OrderItem>)Session["Cart"];
                foreach (OrderItem record in basket)
                {
                    sessionBasket.Add(record);
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

            #region addToSession copy with extra documentation
            ////put this at the end of your book/reservation/buy post method ActionResult and add your records to session basket as described below
            ////please use the complete thing so it works the same in all places

            ////I use this method instead of "+=" because you can only use "+=" if there is already something in the cart
            ////and using this method you can also check if the contents of the cart are valid

            ////List that will be the new contents of the cart
            //List<Order> sessionBasket = new List<Order>();

            ////you can put your records in like sessionBasket.Add(new Order(eventID, eventType);

            ////check if session contains records if so add them to new cart contents
            //try
            //{
            //    //adds valid records to sessionBasket
            //    List<Order> basket = (List<Order>)Session["Cart"];
            //    foreach (Order record in basket)
            //    {
            //        sessionBasket.Add(record);
            //    }
            //}
            //catch
            //{
            //    //when session contains invalid values it is cleared
            //    Session["Cart"] = null;
            //}
            //finally
            //{
            //    //adds new contents to cart
            //    Session["Cart"] = sessionBasket;
            //}

            ////send user to basket after things are added to basket
            //return RedirectToAction("Index", "Basket");
            #endregion
        }

    }
}


