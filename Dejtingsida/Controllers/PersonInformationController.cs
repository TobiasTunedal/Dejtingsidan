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
            deleteData();
            sampleData();
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

        public void sampleData()
        {


            db.PersonInformationModels.Add(new PersonInformationModel
            { Förnamn = "Bert", Efternamn = "Jonsson", Ålder = 56, Stad = "Linköping", Fakta = "Exempel: Kobonde som tränar för mycket på gym och söker min soulmate" });
            db.PersonInformationModels.Add(new PersonInformationModel
            { Förnamn = "Rita", Efternamn = "Lungfeldt", Ålder = 46, Stad = "Kristianstad", Fakta = "Exempel: Letar efter mannen i mitt liv." });
            db.PersonInformationModels.Add(new PersonInformationModel
            { Förnamn = "Klas", Efternamn = "Ingemansson", Ålder = 54, Stad = "Arboga", Fakta = "Exempel: Grisuppfödare på jakt efter den försvunna käeleken." });
            db.PersonInformationModels.Add(new PersonInformationModel
            { Förnamn = "Sergio", Efternamn = "Busquets", Ålder = 39, Stad = "Leksand", Fakta = "Exempel: Letar en efter en kvinna som kan skörda." });
            db.PersonInformationModels.Add(new PersonInformationModel
            { Förnamn = "Ing-britt", Efternamn = "Kåresten", Ålder = 36, Stad = "Junsele", Fakta = "Exempel: Gillar promenader i mitt majsfält" });
            db.PersonInformationModels.Add(new PersonInformationModel
            { Förnamn = "Majvor", Efternamn = "Lenson", Ålder = 38, Stad = "Haparanda", Fakta = "Exempel: Lever 24/7 på majsfältet med min far." });
            db.SaveChanges();
            
        }

        public void deleteData()
        {
              var deleteSamples =
              from p in db.PersonInformationModels
              where p.Fakta.Contains("Exempel") 
              select p;

            foreach (var delete in deleteSamples)
            {
                db.PersonInformationModels.Remove(delete);
            }
            db.SaveChanges();
        }

        public ActionResult SearchPeople(string name)
        {
            var names = from n in db.PersonInformationModels
                        select n;
            if (!String.IsNullOrEmpty(name))
            {
                names = names.Where(c => c.Förnamn.Contains(name));
            }
            return View(names);
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
