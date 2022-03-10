using CliectProject.Models;
using CliectProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Microsoft.AspNet.Identity;

namespace CliectProject.Controllers
{
    [Authorize]
    public class ClientHomeController : Controller
    {
        // GET: ClientPage


        public PaperHelpDbEntities1 db { get; set; }
        // public UserManager MyProperty { get; set; }

        public ClientHomeController()
        {
            db = new PaperHelpDbEntities1();
        }


        public ActionResult Index()
        {

            string userid = User.Identity.GetUserId();

            var orders = db.Orders.Where(x => x.ClientId == userid).ToList();
            //var myorder = db.Orders.Find(id);
            return View(orders);


        }
    }
}