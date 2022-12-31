using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeutyWebModelFirst.Models;


namespace BeutyWebModelFirst.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        Model1Container1 db = new Model1Container1();
        public ActionResult Index()
        {
            return View(db.ProductSet.ToList());
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Product add)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    db.ProductSet.Add(add);
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
                return View(db.ProductSet.Where(x => x.ProductId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Product edit)
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
                return View(db.ProductSet.Where(x => x.ProductId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Product delete)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    delete = db.ProductSet.Where(x => x.ProductId == id).FirstOrDefault();
                    db.ProductSet.Remove(delete);
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