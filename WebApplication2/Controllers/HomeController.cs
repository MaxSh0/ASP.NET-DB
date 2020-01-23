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

            return View();
        }

        public ActionResult Registration()
        {
            ViewBag.Message = "Login";

            return View();
        }

        public ActionResult ClickOnRegistration(string Password)
        {
            if (Password == "admin")
            {

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}