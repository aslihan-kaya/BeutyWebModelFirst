using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeutyWebModelFirst.Models;


namespace BeutyWebModelFirst.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        Model1Container1 db = new Model1Container1();
        public ActionResult Index()
        {
            return View(db.OrderSet.ToList());
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Order add)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    db.OrderSet.Add(add);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (Model1Container1 db = new Model1Container1())
            {
                return View(db.OrderSet.Where(x => x.OrderId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Order edit)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    db.Entry(edit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (Model1Container1 db = new Model1Container1())
            {
                return View(db.OrderSet.Where(x => x.OrderId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Order delete)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    delete = db.OrderSet.Where(x => x.OrderId == id).FirstOrDefault();
                    db.OrderSet.Remove(delete);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

    }
}