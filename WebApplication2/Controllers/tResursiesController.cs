using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;

namespace WebApplication2.Controllers
{
    public class tResursiesController : Controller
    {
        private db_hotelEntities db = new db_hotelEntities();

        // GET: tResursies
        public ActionResult Index()
        {
            return View(db.tResursy.ToList());
        }

        // GET: tResursies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tResursy tResursy = db.tResursy.Find(id);
            if (tResursy == null)
            {
                return HttpNotFound();
            }
            return View(tResursy);
        }

        // GET: tResursies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tResursies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Resursa,Kolvo_na_sklade,Naimenovanie")] tResursy tResursy)
        {
            if (ModelState.IsValid)
            {
                db.tResursy.Add(tResursy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tResursy);
        }

        // GET: tResursies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tResursy tResursy = db.tResursy.Find(id);
            if (tResursy == null)
            {
                return HttpNotFound();
            }
            return View(tResursy);
        }

        // POST: tResursies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Resursa,Kolvo_na_sklade,Naimenovanie")] tResursy tResursy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tResursy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tResursy);
        }

        // GET: tResursies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tResursy tResursy = db.tResursy.Find(id);
            if (tResursy == null)
            {
                return HttpNotFound();
            }
            return View(tResursy);
        }

        // POST: tResursies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tResursy tResursy = db.tResursy.Find(id);
            db.tResursy.Remove(tResursy);
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
