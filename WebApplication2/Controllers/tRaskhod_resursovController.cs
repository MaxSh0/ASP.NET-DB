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
    public class tRaskhod_resursovController : Controller
    {
        private db_hotelEntities db = new db_hotelEntities();

        // GET: tRaskhod_resursov
        public ActionResult Index()
        {
            var tRaskhod_resursov = db.tRaskhod_resursov.Include(t => t.tResursy).Include(t => t.tSotrudnik);
            return View(tRaskhod_resursov.ToList());
        }

        // GET: tRaskhod_resursov/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tRaskhod_resursov tRaskhod_resursov = db.tRaskhod_resursov.Find(id);
            if (tRaskhod_resursov == null)
            {
                return HttpNotFound();
            }
            return View(tRaskhod_resursov);
        }

        // GET: tRaskhod_resursov/Create
        public ActionResult Create()
        {
            ViewBag.ID_Resursa = new SelectList(db.tResursy, "ID_Resursa", "Naimenovanie");
            ViewBag.ID_Rabotnika = new SelectList(db.tSotrudnik, "ID_Rabotnika", "Imya");
            return View();
        }

        // POST: tRaskhod_resursov/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Resursa,Kolvo_ispolzovannykh,ID_Rabotnika")] tRaskhod_resursov tRaskhod_resursov)
        {
            if (ModelState.IsValid)
            {
                db.tRaskhod_resursov.Add(tRaskhod_resursov);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Resursa = new SelectList(db.tResursy, "ID_Resursa", "Naimenovanie", tRaskhod_resursov.ID_Resursa);
            ViewBag.ID_Rabotnika = new SelectList(db.tSotrudnik, "ID_Rabotnika", "Imya", tRaskhod_resursov.ID_Rabotnika);
            return View(tRaskhod_resursov);
        }

        // GET: tRaskhod_resursov/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tRaskhod_resursov tRaskhod_resursov = db.tRaskhod_resursov.Find(id);
            if (tRaskhod_resursov == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Resursa = new SelectList(db.tResursy, "ID_Resursa", "Naimenovanie", tRaskhod_resursov.ID_Resursa);
            ViewBag.ID_Rabotnika = new SelectList(db.tSotrudnik, "ID_Rabotnika", "Imya", tRaskhod_resursov.ID_Rabotnika);
            return View(tRaskhod_resursov);
        }

        // POST: tRaskhod_resursov/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Resursa,Kolvo_ispolzovannykh,ID_Rabotnika")] tRaskhod_resursov tRaskhod_resursov)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRaskhod_resursov).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Resursa = new SelectList(db.tResursy, "ID_Resursa", "Naimenovanie", tRaskhod_resursov.ID_Resursa);
            ViewBag.ID_Rabotnika = new SelectList(db.tSotrudnik, "ID_Rabotnika", "Imya", tRaskhod_resursov.ID_Rabotnika);
            return View(tRaskhod_resursov);
        }

        // GET: tRaskhod_resursov/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tRaskhod_resursov tRaskhod_resursov = db.tRaskhod_resursov.Find(id);
            if (tRaskhod_resursov == null)
            {
                return HttpNotFound();
            }
            return View(tRaskhod_resursov);
        }

        // POST: tRaskhod_resursov/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tRaskhod_resursov tRaskhod_resursov = db.tRaskhod_resursov.Find(id);
            db.tRaskhod_resursov.Remove(tRaskhod_resursov);
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
