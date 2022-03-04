using CliectProject.Models;
using CliectProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                model.startDate = DateTime.Now;
            }

            double hourtoday = model.duration;

         
            Order O = new Order();
            O.ServiceId = model.ServiceId;
            O.Price = model.Price;
            O.duration =(byte?)model.duration;
            O.IsNormal = model.IsNormal;
            O.Description = model.Description;
            O.NoOfPaper = model.NoOfPaper;
            O.OrderStatus = (byte)OrderStatus.WaitPayment;
            O.startDate = model.startDate;

          

            O.finishedDate = DateTime.Now.AddHours(hourtoday);
           

            db.Orders.Add(O);
            db.SaveChanges();
                int latestOrderId = O.ID;

            return View(O);
        }




        //[HttpGet]
        public ActionResult ClientPage(int id)
        {
            var myorder = db.Orders.Find(id);
            myorder.OrderStatus = (byte)OrderStatus.PindingAdmin;
            db.SaveChanges();
            var O = db.Orders.ToList();



            return View(O);
        }
        [HttpPost]
        public ActionResult ClientPage(Order Update)
        {
            Update.OrderStatus =(byte?)OrderStatus.PindingAdmin;
            db.Entry(Update).State = EntityState.Modified;
            db.SaveChanges();
            //Order a = new Order() { ID = id };


            //a.OrderStatus = (byte?)OrderStatus.PindingAdmin;



            return View(Update);
        }



        public ActionResult AddOrder_pay(int id)
        {
            //Order a = new Order() { ID = id };
            var myorder = db.Orders.Find(id);
            myorder.startDate = DateTime.Now;
            double hourtoday1 = (double)myorder.duration;
            myorder.finishedDate = DateTime.Now.AddHours(hourtoday1);
            db.SaveChanges();
            return View(myorder);
        }


        public ActionResult BackToOrder(int id)
        {
            //var myorder = db.Orders.Find(id);
            Order myorder = db.Orders.Find(id);
            db.Orders.Remove(myorder);
            db.SaveChanges();
            var O = db.Services.FirstOrDefault(b => b.Id == id);

            return View(O);

        }
        



    }
}