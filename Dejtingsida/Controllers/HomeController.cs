using Dejtingsida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dejtingsida.Controllers
{
    public class HomeController : Controller
    {
        private PersonContext db = new PersonContext();
        public ActionResult Index()
        {
            var users = db.PersonInformationModels.OrderBy(x => x.PersonID).Take(6).ToList();
            
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