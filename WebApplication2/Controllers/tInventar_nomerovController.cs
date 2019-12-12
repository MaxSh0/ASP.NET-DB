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
    public class tInventar_nomerovController : Controller
    {
        private db_hotelEntities db = new db_hotelEntities();

        // GET: tInventar_nomerov
        public ActionResult Index()
        {
            var tInventar_nomerov = db.tInventar_nomerov.Include(t => t.tNomer);
            return View(tInventar_nomerov.ToList());
        }

        // GET: tInventar_nomerov/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tInventar_nomerov tInventar_nomerov = db.tInventar_nomerov.Find(id);
            if (tInventar_nomerov == null)
            {
                return HttpNotFound();
            }
            return View(tInventar_nomerov);
        }

        // GET: tInventar_nomerov/Create
        public ActionResult Create()
        {
            ViewBag.ID_Nomer = new SelectList(db.tNomer, "ID_Nomer", "Tip_nomera");
            return View();
        }

        // POST: tInventar_nomerov/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Nomer,Naimenovanie,ID_inventarnoy_edinitsy,Kolvo_v_nomere")] tInventar_nomerov tInventar_nomerov)
        {
            if (ModelState.IsValid)
            {
                db.tInventar_nomerov.Add(tInventar_nomerov);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Nomer = new SelectList(db.tNomer, "ID_Nomer", "Tip_nomera", tInventar_nomerov.ID_Nomer);
            return View(tInventar_nomerov);
        }

        // GET: tInventar_nomerov/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tInventar_nomerov tInventar_nomerov = db.tInventar_nomerov.Find(id);
            if (tInventar_nomerov == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Nomer = new SelectList(db.tNomer, "ID_Nomer", "Tip_nomera", tInventar_nomerov.ID_Nomer);
            return View(tInventar_nomerov);
        }

        // POST: tInventar_nomerov/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Nomer,Naimenovanie,ID_inventarnoy_edinitsy,Kolvo_v_nomere")] tInventar_nomerov tInventar_nomerov)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tInventar_nomerov).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Nomer = new SelectList(db.tNomer, "ID_Nomer", "Tip_nomera", tInventar_nomerov.ID_Nomer);
            return View(tInventar_nomerov);
        }

        // GET: tInventar_nomerov/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tInventar_nomerov tInventar_nomerov = db.tInventar_nomerov.Find(id);
            if (tInventar_nomerov == null)
            {
                return HttpNotFound();
            }
            return View(tInventar_nomerov);
        }

        // POST: tInventar_nomerov/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tInventar_nomerov tInventar_nomerov = db.tInventar_nomerov.Find(id);
            db.tInventar_nomerov.Remove(tInventar_nomerov);
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
