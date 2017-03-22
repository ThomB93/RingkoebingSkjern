using RingkoebingSkjern.Models;
using System.Web.Mvc;

namespace RingkoebingSkjern.Controllers
{
    public class TovholderController : Controller
    {
        //[HttpGet]
        public ActionResult OpretNyFrivillig()
        {
            return View(new Frivillig());
        }
        
        [HttpPost]
        public ActionResult OpretNyFrivillig(Frivillig frivillig)
        {
            
            return View(new Frivillig());
        }
    }
}