﻿using RingkoebingSkjern.DAL;
using RingkoebingSkjern.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RingkoebingSkjern.Controllers
{
    public class HomeController : Controller
    {
        private DbConnect dbc;
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tidsreg()
        {
            return View();
        }

        [Authorize(Roles = "Frivillig")] //url auth
        public ActionResult RegistrerTid()
        {
            List<Laug> laugListe = GetAllLaug();
            ViewBag.LaugListe = laugListe;
            ViewBag.CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return View();
        }
        [HttpPost]
        public ActionResult RegistrerTid(Tidsregistrering model)
        {
            if (ModelState.IsValid)
            {
                dbc = new DbConnect();
                dbc.InsertTidsRegistrering(model.FrivilligId, model.LaugId, model.StartTid);
            }
            return View("Index");
        }

        [Authorize(Roles = "Frivillig")] //url auth
        public ActionResult EfteregistrerTid()
        {
            List<Laug> laugListe = GetAllLaug();
            ViewBag.LaugListe = laugListe;
            return View();
        }

        private List<Laug> GetAllLaug()
        {
            dbc = new DbConnect();
            List<Laug> laugListe = dbc.SelectAllLaug(); //hent laug fra DB
            return laugListe;
        }
        public int GetLaugId(string laugNavn)
        {
            List<Laug> laugListe = GetAllLaug();
            foreach (var item in laugListe)
            {
                if(laugNavn == item.Navn)
                {
                    return item.Id;
                }
            }
            return -1;
        }
    }
}