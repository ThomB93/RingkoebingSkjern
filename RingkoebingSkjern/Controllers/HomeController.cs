using RingkoebingSkjern.DAL;
using RingkoebingSkjern.Models;
using System.Web.Mvc;

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

        public ActionResult RegistrerTid()
        {
            return View();
        }
    }
}