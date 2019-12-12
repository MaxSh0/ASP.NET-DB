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
    public class tKlientsController : Controller
    {
        private db_hotelEntities db = new db_hotelEntities();

        // GET: tKlients
        public ActionResult Index()
        {
            return View(db.tKlient.ToList());
        }

        // GET: tKlients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tKlient tKlient = db.tKlient.Find(id);
            if (tKlient == null)
            {
                return HttpNotFound();
            }
            return View(tKlient);
        }

        // GET: tKlients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tKlients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Imya,Familiya,ID_Klient,Data_zaseleniya,Data_viseleniya")] tKlient tKlient)
        {
            if (ModelState.IsValid)
            {
                db.tKlient.Add(tKlient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tKlient);
        }

        // GET: tKlients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tKlient tKlient = db.tKlient.Find(id);
            if (tKlient == null)
            {
                return HttpNotFound();
            }
            return View(tKlient);
        }

        // POST: tKlients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Imya,Familiya,ID_Klient,Data_zaseleniya,Data_viseleniya")] tKlient tKlient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tKlient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tKlient);
        }

        // GET: tKlients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tKlient tKlient = db.tKlient.Find(id);
            if (tKlient == null)
            {
                return HttpNotFound();
            }
            return View(tKlient);
        }

        // POST: tKlients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tKlient tKlient = db.tKlient.Find(id);
            db.tKlient.Remove(tKlient);
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
