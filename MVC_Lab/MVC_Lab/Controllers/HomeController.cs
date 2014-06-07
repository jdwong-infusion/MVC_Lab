using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Lab.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Message = "This is where you would put your home page.";

            return View();
        }

        //
        // GET: /Home/About

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        //
        // GET: /Home/Unauthorized

        public ActionResult Unauthorized()
        {
            ViewBag.Message = "You are not authorized to perform the action you have requested.";

            return View();
        }

    }
}
