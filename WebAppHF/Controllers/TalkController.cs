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
            Talk talk = rep.GetTalk(id);
            return View(talk);
        }

        public ActionResult Book(int id)
        {
            Talk talk = rep.GetTalk(id);
            TalkModel viewmodel = new TalkModel(talk);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Book(TalkModel talk)
        {
            if (ModelState.IsValid)
            {
                Talk dummy = rep.GetTalk(talk.ID);
                talk.Talk = dummy;
                CartModel cart = (CartModel)Session["Cart"];
                //krijg amount description etc uit je form

                //als cart in de session leeg is maak een nieuwe
                if (cart == null)
                {
                    cart = new CartModel();
                }
                OrderItem order = new OrderItem(talk.Talk);
                order.Amount = talk.Amount;
                cart.AddOrderItem(order);
                /*
                 * als amount hoger is als 0 stop het in cart met de volgende regel code:
                 * 
                 * cart.AddOrderItem(onderdeel uit je cart);
                 *
                 * een orderItem is nu wat vroeger record was met als verschil dat het
                 * nu een heel event bevat ipv alleen een event id, dit maakt het meer
                 * O.O. en beter uitbreidbaar
                 * 
                 * om het goed te laten werken moet in een orderItem hetvolgende zitten:
                 * - Event
                 * - Amount
                 * - TotalPrice 
                 * 
                 * TotalPrice wordt automatisch gedaan op het moment dat je AddOrderItem doet
                 * Hiervoor moet je wel zorgen dat amount > 0 en Event != null
                */

                //stop de hele cart weer terug in de session
                Session["Cart"] = cart;
                return RedirectToAction("Success", "Cart");
            }
            return RedirectToAction("Failure", "Cart");
        }


        /*Mark: Ik heb dit uitgecomment omdat er wat models veranderd zijn waardoor
         *hier syntax errors ontstonden. Als je dit gedeelte aanpast op de verbeterde
         *modellen komt het helemaal goed.   */

        //[HttpPost]
        //public ActionResult Book(TalkModel talkmodel)
        //{
        //    Talk talk = rep.GetTalkById(talkmodel.Talk.ID);
        //    talkmodel.Talk = talk;
        //    CartModel cart = (CartModel)Session["Cart"];
        //    if (Session["Cart"] == null)
        //    {
        //        //Session["Cart"] = new CartModel();
        //        //((CartModel)Session["Cart"]).TalkModelItems.Add(talkmodel);
        //        //((CartModel)Session["Cart"]).Items.Add(talkmodel);
        //        cart.TalkModelItems.Add(talkmodel);
        //        cart.Items.Add(talkmodel);
        //        Session["Cart"] = cart;
        //        return RedirectToAction("AddedToCart");
        //    }
        //    //((CartModel)Session["Cart"]).TalkModelItems.Add(talkmodel);
        //    //((CartModel)Session["Cart"]).Items.Add(talkmodel);
        //    cart.TalkModelItems.Add(talkmodel);
        //    cart.Items.Add(talkmodel);
        //    Session["Cart"] = cart;
        //    return RedirectToAction("AddedToCart");

        //}

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