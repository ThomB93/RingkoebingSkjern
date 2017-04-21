using RingkoebingSkjern.DAL;
using RingkoebingSkjern.Models;
using System.Collections.Generic;
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
        public ActionResult Tidsreg()
        {
            return View();
        }

        [Authorize(Roles = "Frivillig")] //url auth
        public ActionResult RegistrerTid()
        {
            List<Laug> laugListe = GetAllLaug();
            ViewBag.LaugListe = laugListe;
            return View();
        }
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
    }
}