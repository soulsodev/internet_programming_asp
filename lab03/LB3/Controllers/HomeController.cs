using lab03.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace lab03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
