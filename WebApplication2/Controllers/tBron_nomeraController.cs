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
    public class tBron_nomeraController : Controller
    {
        private db_hotelEntities db = new db_hotelEntities();

        // GET: tBron_nomera
        public ActionResult Index()
        {
            var tBron_nomera = db.tBron_nomera.Include(t => t.tKlient).Include(t => t.tNomer).Include(t => t.tSotrudnik);
            return View(tBron_nomera.ToList());
        }

        // GET: tBron_nomera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tBron_nomera tBron_nomera = db.tBron_nomera.Find(id);
            if (tBron_nomera == null)
            {
                return HttpNotFound();
            }
            return View(tBron_nomera);
        }

        // GET: tBron_nomera/Create
        public ActionResult Create()
        {
            ViewBag.ID_Klient = new SelectList(db.tKlient, "ID_Klient", "Imya");
            ViewBag.ID_Nomer = new SelectList(db.tNomer, "ID_Nomer", "Tip_nomera");
            ViewBag.ID_Rabotnika = new SelectList(db.tSotrudnik, "ID_Rabotnika", "Imya");
            return View();
        }

        // POST: tBron_nomera/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Nomer,ID_Rabotnika,ID_Klient,Data_zaseleniya,Data_viseleniya")] tBron_nomera tBron_nomera)
        {
            if (ModelState.IsValid)
            {
                db.tBron_nomera.Add(tBron_nomera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Klient = new SelectList(db.tKlient, "ID_Klient", "Imya", tBron_nomera.ID_Klient);
            ViewBag.ID_Nomer = new SelectList(db.tNomer, "ID_Nomer", "Tip_nomera", tBron_nomera.ID_Nomer);
            ViewBag.ID_Rabotnika = new SelectList(db.tSotrudnik, "ID_Rabotnika", "Imya", tBron_nomera.ID_Rabotnika);
            return View(tBron_nomera);
        }

        // GET: tBron_nomera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tBron_nomera tBron_nomera = db.tBron_nomera.Find(id);
            if (tBron_nomera == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Klient = new SelectList(db.tKlient, "ID_Klient", "Imya", tBron_nomera.ID_Klient);
            ViewBag.ID_Nomer = new SelectList(db.tNomer, "ID_Nomer", "Tip_nomera", tBron_nomera.ID_Nomer);
            ViewBag.ID_Rabotnika = new SelectList(db.tSotrudnik, "ID_Rabotnika", "Imya", tBron_nomera.ID_Rabotnika);
            return View(tBron_nomera);
        }

        // POST: tBron_nomera/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Nomer,ID_Rabotnika,ID_Klient,Data_zaseleniya,Data_viseleniya")] tBron_nomera tBron_nomera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBron_nomera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Klient = new SelectList(db.tKlient, "ID_Klient", "Imya", tBron_nomera.ID_Klient);
            ViewBag.ID_Nomer = new SelectList(db.tNomer, "ID_Nomer", "Tip_nomera", tBron_nomera.ID_Nomer);
            ViewBag.ID_Rabotnika = new SelectList(db.tSotrudnik, "ID_Rabotnika", "Imya", tBron_nomera.ID_Rabotnika);
            return View(tBron_nomera);
        }

        // GET: tBron_nomera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tBron_nomera tBron_nomera = db.tBron_nomera.Find(id);
            if (tBron_nomera == null)
            {
                return HttpNotFound();
            }
            return View(tBron_nomera);
        }

        // POST: tBron_nomera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tBron_nomera tBron_nomera = db.tBron_nomera.Find(id);
            db.tBron_nomera.Remove(tBron_nomera);
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
