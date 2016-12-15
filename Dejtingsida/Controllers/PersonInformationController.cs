using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dejtingsida.Models;

namespace Dejtingsida.Controllers
{
    public class PersonInformationController : Controller
    {
        private PersonContext db = new PersonContext();

        // GET: PersonInformation
        public ActionResult Index()
        {
            return View(db.PersonInformationModels.ToList());
        }

        // GET: PersonInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInformationModel personInformationModel = db.PersonInformationModels.Find(id);
            if (personInformationModel == null)
            {
                return HttpNotFound();
            }
            return View(personInformationModel);
        }

        // GET: PersonInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,Förnamn,Efternamn,Ålder,Stad,Fakta")] PersonInformationModel personInformationModel)
        {
            if (ModelState.IsValid)
            {
                db.PersonInformationModels.Add(personInformationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personInformationModel);
        }

        // GET: PersonInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInformationModel personInformationModel = db.PersonInformationModels.Find(id);
            if (personInformationModel == null)
            {
                return HttpNotFound();
            }
            return View(personInformationModel);
        }

        // POST: PersonInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,Förnamn,Efternamn,Ålder,Stad,Fakta")] PersonInformationModel personInformationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personInformationModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personInformationModel);
        }

        // GET: PersonInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonInformationModel personInformationModel = db.PersonInformationModels.Find(id);
            if (personInformationModel == null)
            {
                return HttpNotFound();
            }
            return View(personInformationModel);
        }

        // POST: PersonInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonInformationModel personInformationModel = db.PersonInformationModels.Find(id);
            db.PersonInformationModels.Remove(personInformationModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
