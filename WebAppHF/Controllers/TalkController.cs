﻿using System;
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
            // simpel talk events ophalen en doorgeven aan view
            IEnumerable<Talk> list = rep.GetTalks();
            return View(list);
        }

        public ActionResult Detail(int id)
        {
            //vanuit index view wordt er id doorgegeven om de gehele event op te halen
            Talk talk = rep.GetTalk(id);
            return View(talk);
        }

        public ActionResult Book(int id)
        {
            //vanuit detail view wordt id van de corresponderende doorgegeven om opnieuw de gehele op te halen
            Talk talk = rep.GetTalk(id);
            TalkModel viewmodel = new TalkModel(talk);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Book(TalkModel talk)
        {
            // postback variant van book, hier wordt de talk event gegeven met een amount field mbv een viewmodel, vervolgens in de cart session gestopt
            // check of alle velden van de viewmodel kloppen
            if (ModelState.IsValid)
            {
                // aanmaak dummy om de event uit de database te halen
                Talk dummy = rep.GetTalk(talk.ID);
                talk.Talk = dummy;
                CartModel cart = (CartModel)Session["Cart"];

                //als cart in de session leeg is maak een nieuwe instance
                if (cart == null)
                {
                    cart = new CartModel();
                }
                // aanmaak orderitem om in de cart te stoppen
                OrderItem order = new OrderItem(talk.Talk);
                order.Amount = talk.Amount;
                cart.AddOrderItem(order);
                
                Session["Cart"] = cart;
                return RedirectToAction("AddedToCart");
            }
            return RedirectToAction("Failure", "Cart");
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