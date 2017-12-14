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
            List<Jazz> JazzActs = repo.GetAll();

            return View(JazzActs);
        }

        public ActionResult Detail()
        {
            //TODO: ID moet nog dynamisch
            Jazz jazz = repo.GetJazzByID(1);

            return View(jazz);
        }
    }
}