using System.Collections.Generic;
using RingkoebingSkjern.DAL;
using RingkoebingSkjern.Models;
using System.Web.Mvc;

namespace RingkoebingSkjern.Controllers
{
    public class HomeController : Controller
    {
        private DbConnect dbc;
        public ActionResult Index()
        {
            dbc = new DbConnect();
            //ViewBag.Message = dbc.Insert();

            Login login = dbc.SelectUser("Frants"); //test
            ViewBag.Brugernavn = login.Brugernavn;
            ViewBag.Adgangskode = login.Adgangskode;

            return View();
        }

        public ActionResult RegistrerTid()
        {
            dbc = new DbConnect();
            List<Laug> laugListe = dbc.SelectAllLaug();
            ViewBag.LaugListe = laugListe;
            return View();
        }
        public ActionResult EfteregistrerTid()
        {
            return View();
        }
    }
}