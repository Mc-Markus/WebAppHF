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

        public ActionResult Detail(int id)
        {
            Talk talk = rep.GetTalkById(id);
            return View(talk);
        }

        public ActionResult Book(int id)
        {
            Talk talk = rep.GetTalkById(id);
            TalkModel viewmodel = new TalkModel(talk);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Book(TalkModel talkmodel)
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new CartModel();
                ((CartModel)Session["Cart"]).TalkModelItems.Add(talkmodel);
                ((CartModel)Session["Cart"]).Items.Add(talkmodel);
                return RedirectToAction("AddedToCart");
            }
            else
            {
                ((CartModel)Session["Cart"]).TalkModelItems.Add(talkmodel);
                ((CartModel)Session["Cart"]).Items.Add(talkmodel);
                return RedirectToAction("AddedToCart");
            }
            
        }

        public ActionResult AddedToCart()
        {
            return View();
        }

        public ActionResult AddFailed()
        {
            return View();
        }
    }
}