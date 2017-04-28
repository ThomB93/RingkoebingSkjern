using RingkoebingSkjern.DAL;
using RingkoebingSkjern.Models;
using System;
using System.Web.Mvc;

namespace RingkoebingSkjern.Controllers
{
    public class TovholderController : Controller
    {
        private DbConnect dbc;
        //[HttpGet]
        //[Authorize(Roles = "Tovholder")] //url auth
        public ActionResult OpretNyFrivillig()
        {
            return View(new Frivillig());
        }
        
        [HttpPost]
        public ActionResult OpretNyFrivillig(Frivillig model) //Indsætter ny frivillig i DB fra OpretNyFrivillig view
        {
            if (ModelState.IsValid)
            {
                dbc = new DbConnect();
                dbc.InsertFrivillig(model.Fornavn, model.Efternavn, model.Telefon,
                    model.Adresse, model.Email, Convert.ToInt32(model.PostNr));
            }
            TempData["successmessage"] = "Frivillig blev oprettet!";
            return RedirectToAction("Index", "Home");
        }
    }
}