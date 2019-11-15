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
        DolznostContext db = new DolznostContext();
        public ActionResult Index()
        {
            var sotrudniks = db.Sotrudnik.Include(p => p.Dolzhnost);
            return View(sotrudniks.ToList());
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