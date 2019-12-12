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
    public class tSotrudniksController : Controller
    {
        private db_hotelEntities db = new db_hotelEntities();

        // GET: tSotrudniks
        public ActionResult Index()
        {
            var tSotrudnik = db.tSotrudnik.Include(t => t.tDolzhnost);
            return View(tSotrudnik.ToList());
        }

        // GET: tSotrudniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tSotrudnik tSotrudnik = db.tSotrudnik.Find(id);
            if (tSotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(tSotrudnik);
        }

        // GET: tSotrudniks/Create
        public ActionResult Create()
        {
            ViewBag.ID_Dolzhnost = new SelectList(db.tDolzhnost, "DolzhnostID", "Naimenovanie");
            return View();
        }

        // POST: tSotrudniks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Imya,Familiya,Vysluga,ID_Dolzhnost,ID_Rabotnika,Vozrast")] tSotrudnik tSotrudnik)
        {
            if (ModelState.IsValid)
            {
                db.tSotrudnik.Add(tSotrudnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Dolzhnost = new SelectList(db.tDolzhnost, "DolzhnostID", "Naimenovanie", tSotrudnik.ID_Dolzhnost);
            return View(tSotrudnik);
        }

        // GET: tSotrudniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tSotrudnik tSotrudnik = db.tSotrudnik.Find(id);
            if (tSotrudnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Dolzhnost = new SelectList(db.tDolzhnost, "DolzhnostID", "Naimenovanie", tSotrudnik.ID_Dolzhnost);
            return View(tSotrudnik);
        }

        // POST: tSotrudniks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Imya,Familiya,Vysluga,ID_Dolzhnost,ID_Rabotnika,Vozrast")] tSotrudnik tSotrudnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tSotrudnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Dolzhnost = new SelectList(db.tDolzhnost, "DolzhnostID", "Naimenovanie", tSotrudnik.ID_Dolzhnost);
            return View(tSotrudnik);
        }

        // GET: tSotrudniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tSotrudnik tSotrudnik = db.tSotrudnik.Find(id);
            if (tSotrudnik == null)
            {
                return HttpNotFound();
            }
            return View(tSotrudnik);
        }

        // POST: tSotrudniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tSotrudnik tSotrudnik = db.tSotrudnik.Find(id);
            db.tSotrudnik.Remove(tSotrudnik);
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
