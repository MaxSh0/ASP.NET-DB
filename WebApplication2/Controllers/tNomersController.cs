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
    public class tNomersController : Controller
    {
        private db_hotelEntities db = new db_hotelEntities();

        // GET: tNomers
        public ActionResult Index()
        {
            return View(db.tNomer.ToList());
        }

        // GET: tNomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tNomer tNomer = db.tNomer.Find(id);
            if (tNomer == null)
            {
                return HttpNotFound();
            }
            return View(tNomer);
        }

        // GET: tNomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tNomers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Nomer,Zanyat,Tip_nomera")] tNomer tNomer)
        {
            if (ModelState.IsValid)
            {
                db.tNomer.Add(tNomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tNomer);
        }

        // GET: tNomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tNomer tNomer = db.tNomer.Find(id);
            if (tNomer == null)
            {
                return HttpNotFound();
            }
            return View(tNomer);
        }

        // POST: tNomers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Nomer,Zanyat,Tip_nomera")] tNomer tNomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tNomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tNomer);
        }

        // GET: tNomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tNomer tNomer = db.tNomer.Find(id);
            if (tNomer == null)
            {
                return HttpNotFound();
            }
            return View(tNomer);
        }

        // POST: tNomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tNomer tNomer = db.tNomer.Find(id);
            db.tNomer.Remove(tNomer);
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
