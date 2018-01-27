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

            DisplayRecord drw = new DisplayRecord(passePartoutWeekend, new Record());
            DisplayRecord drd = new DisplayRecord(passePartoutDay, new Record());
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
            List<DisplayRecord> sessionBasket = new List<DisplayRecord>();
            if (book.DayPassePartout.Record.Amount > 0)
            {
                sessionBasket.Add(book.DayPassePartout);
            }
            if (book.WeekendPassePartout.Record.Amount > 0)
            {
                sessionBasket.Add(book.WeekendPassePartout);
            }

            foreach (DisplayRecord dr in book.DayEvents)
            {
                if (dr.Record.Amount > 0)
                {
                    sessionBasket.Add(dr);
                }
            }

            try
            {
                List<DisplayRecord> drs = (List<DisplayRecord>)Session["Cart"];
                foreach (DisplayRecord dr in drs)
                {
                    sessionBasket.Add(dr);
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