using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CliectProject.Models;
using CliectProject.Models.ViewModels;

namespace CliectProject.Controllers
{
    public class HomeController : Controller
    {
        public PaperHelpDbEntities1 db = new PaperHelpDbEntities1();
        public ActionResult Index()
        {
            var s = db.Services.ToList();
            return View(s);
           
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