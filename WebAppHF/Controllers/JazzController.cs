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
        // GET: Jazz
        public ActionResult Index()
        {
            List<JazzDaySummary> summarys = repo.GetDaySummarys();

            if (summarys == null)
            {
                return RedirectToAction("Index", "HomeController", null);
            }

            return View(summarys);
        }

        public ActionResult Day(DateTime date)
        {
            List<Jazz> JazzActs = repo.GetJazzActsByDay(date);

            return View(JazzActs);
        }

        [HttpGet]
        public ActionResult Book(DateTime date)
        {
            List<Jazz> JazzActs = repo.GetJazzActsByDay(date);
            Jazz passePartoutWeekend = repo.GetPassePartoutWeekend();
            Jazz passePartoutDay = repo.GetPassePartoutDay(date);

            DisplayRecord drw = new DisplayRecord(passePartoutWeekend, new Record(passePartoutWeekend.ID));
            DisplayRecord drd = new DisplayRecord(passePartoutDay, new Record(passePartoutDay.ID));
            List<DisplayRecord> dre = new List<DisplayRecord>();

            foreach (Jazz jazz in JazzActs)
            {
                DisplayRecord dr = new DisplayRecord(jazz, new Record(jazz.ID));
                dre.Add(dr);
            }

            JazzBook jazzBook = new JazzBook(drd, drw, dre);

            //string hall = ((Jazz)dr.Event).Hall;
            return View(jazzBook);

        }

        //[HttpPost]
        public ActionResult AddToSession(JazzBook MyTestParameter)
        {
            JazzBook book = MyTestParameter;

            List<Record> sessionBasket = new List<Record>();
            if (book.DayPassePartout.Record.Amount > 0)
            {
                sessionBasket.Add(book.DayPassePartout.Record);
            }
            if (book.WeekendPassePartout.Record.Amount > 0)
            {
                sessionBasket.Add(book.WeekendPassePartout.Record);
            }

            foreach (DisplayRecord dr in book.DayEvents)
            {
                if (dr.Record.Amount > 0)
                {
                    sessionBasket.Add(dr.Record);
                }
            }

            try
            {
                List<Record> basket = (List<Record>)Session["Cart"];
                foreach (Record record in basket)
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

            return RedirectToAction("Index", "Home");
        }

    }
}