using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "user, admin")]
        public ActionResult Booking()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Offers()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Your Gallery page.";

            return View();
        }

        public ActionResult Restaurant()
        {
            ViewBag.Message = "Your Restaurant page.";

            return View();
        }
    }
}