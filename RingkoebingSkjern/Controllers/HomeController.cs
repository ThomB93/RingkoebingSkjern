using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RingkoebingSkjern.DAL;
using RingkoebingSkjern.Models;

namespace RingkoebingSkjern.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DbConnect dbc = new DbConnect();
            //ViewBag.Message = dbc.Insert();
            Login login = dbc.SelectUser("Frants");
            ViewBag.Brugernavn = login.Brugernavn;
            ViewBag.Adgangskode = login.Adgangskode;

            return View();
        }
    }
}