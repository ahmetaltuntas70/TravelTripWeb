using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        Context c = new Context();

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admins)
        {
            c.Admins.Add(admins);
            c.SaveChanges();
            return RedirectToAction("GirişYap", "Login");
        }
    }
}