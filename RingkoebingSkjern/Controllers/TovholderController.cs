using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RingkoebingSkjern.Models;

namespace RingkoebingSkjern.Controllers
{
    public class TovholderController : Controller
    {
        // GET: Tovholder
        public ActionResult OpretNyFrivillig()
        {
            return View(new Frivillig());
        }

        public void IndsætData()
        {
            
        }
    }
}