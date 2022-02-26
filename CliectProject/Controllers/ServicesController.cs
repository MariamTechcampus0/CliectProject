using CliectProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CliectProject.Controllers
{
    public class ServicesController : Controller
    {
         public PaperHelpDbEntities1 db = new PaperHelpDbEntities1();
        
        // GET: Services
        public ActionResult Index()
        {
            /*Select all services*/
            var s = db.Services.ToList();
            return View(s);
        }

        public ActionResult Order( int id)
        {

            // get book by id
            var O = db.Services.FirstOrDefault(b => b.Id == id);

           

            return View(O);
            
        }
    }
}