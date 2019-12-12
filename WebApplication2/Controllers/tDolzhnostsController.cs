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
    public class tDolzhnostsController : Controller
    {
        private db_hotelEntities db = new db_hotelEntities();

        // GET: tDolzhnosts
        public ActionResult Index()
        {
            return View(db.tDolzhnost.ToList());
        }

        // GET: tDolzhnosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDolzhnost tDolzhnost = db.tDolzhnost.Find(id);
            if (tDolzhnost == null)
            {
                return HttpNotFound();
            }
            return View(tDolzhnost);
        }

        // GET: tDolzhnosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tDolzhnosts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DolzhnostID,Naimenovanie")] tDolzhnost tDolzhnost)
        {
            if (ModelState.IsValid)
            {
                db.tDolzhnost.Add(tDolzhnost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tDolzhnost);
        }

        // GET: tDolzhnosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDolzhnost tDolzhnost = db.tDolzhnost.Find(id);
            if (tDolzhnost == null)
            {
                return HttpNotFound();
            }
            return View(tDolzhnost);
        }

        // POST: tDolzhnosts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DolzhnostID,Naimenovanie")] tDolzhnost tDolzhnost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tDolzhnost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tDolzhnost);
        }

        // GET: tDolzhnosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tDolzhnost tDolzhnost = db.tDolzhnost.Find(id);
            if (tDolzhnost == null)
            {
                return HttpNotFound();
            }
            return View(tDolzhnost);
        }

        // POST: tDolzhnosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tDolzhnost tDolzhnost = db.tDolzhnost.Find(id);
            db.tDolzhnost.Remove(tDolzhnost);
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
