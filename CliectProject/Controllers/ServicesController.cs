using CliectProject.Models;
using CliectProject.Models.ViewModels;
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
        [HttpGet]
        public ActionResult Order( int id)
        {

            // get services by id
            var O = db.Services.FirstOrDefault(b => b.Id == id);
           
            return View(O);
            
        }
        
        public PartialViewResult AddOrder_2(int id)
        {
            //CliectProject.Models.Order order = new Models.Order() { ServiceId = id };

            AddOrder a = new AddOrder() { ServiceId = id };

            return PartialView("AddOrderView", a);
            //return PartialView(");
        }

        [HttpPost]
        public ActionResult AddOrder_3(AddOrder model)
        {
            //AddOrder o = new AddOrder();
            //if (ModelState.IsValid)
            //{
                var s = db.Services.FirstOrDefault(b => b.Id == model.ServiceId);
            if (model.IsNormal)
            {
                model.Price = (decimal)(model.NoOfPaper * s.NormalPrice);
                model.duration = (byte)(model.NoOfPaper * s.NormalHour);
                model.Description = model.Description;
                model.startDate = DateTime.Today;
            }
            else 

            {
                model.Price = (decimal)(model.NoOfPaper * s.FastPrice);
                model.duration = (byte)(model.NoOfPaper * s.FastHour);
                model.Description = model.Description;
                model.startDate = DateTime.Today;
            }

            double hourtoday = model.duration / 24;

         
            Order O = new Order();
            O.ServiceId = model.ServiceId;
            O.Price = model.Price;
            O.duration =(byte?)model.duration;
            O.IsNormal = model.IsNormal;
            O.Description = model.Description;
            O.NoOfPaper = model.NoOfPaper;
            O.OrderStatus = (byte)OrderStatus.WaitPayment;
            O.startDate = model.startDate;   
            
            if (hourtoday >= 1)
            {
               
            }


            db.Orders.Add(O);
            db.SaveChanges();
                int latestOrderId = O.ID;

            return View(O);
        }





        [HttpPost]
        public ActionResult Payment(Order model)
        {


            return View(model);
        }


    }
}