using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeutyWebModelFirst.Models;

namespace BeutyWebModelFirst.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        Model1Container1 db = new Model1Container1();
        public ActionResult Index()
        {
            return View(db.BrandSet.ToList());
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Brand add)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    db.BrandSet.Add(add);
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
                return View(db.BrandSet.Where(x => x.BrandId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Brand edit)
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
                return View(db.BrandSet.Where(x => x.BrandId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Brand delete)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    delete = db.BrandSet.Where(x => x.BrandId == id).FirstOrDefault();
                    db.BrandSet.Remove(delete);
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