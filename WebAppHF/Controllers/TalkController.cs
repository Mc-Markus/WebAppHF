using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHF.Models;
using WebAppHF.Repositories;

namespace WebAppHF.Controllers
{
    public class TalkController : Controller
    {
        ITalkRepo rep = new TalkRepo();
        // GET: Talk
        public ActionResult Index()
        {
            IEnumerable<Talk> list = rep.GetTalks();
            return View(list);
        }
    }
}