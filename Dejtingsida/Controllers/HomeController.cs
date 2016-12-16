using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dejtingsida.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult LetaPartner()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
         public ActionResult Vänlista()
        {
            ViewBag.Message = "Din vänlista";

            return View();
        }
        
    }
}