using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (var db = new db_hotelEntities())
            {
                var sotrudniki = db.tSotrudnik.Include("tDolzhnost").ToList();

                return View(sotrudniki);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tSotrudnik model)
        {
            using (var db = new db_hotelEntities())
            {
                db.tSotrudnik.Add(model);
                db.SaveChanges();
            }

                return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}