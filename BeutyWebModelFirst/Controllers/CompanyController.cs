using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeutyWebModelFirst.Models;

namespace BeutyWebModelFirst.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        Model1Container1 db = new Model1Container1();
        public ActionResult Index()
        {
            return View(db.CompanySet.ToList());
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Company add)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    db.CompanySet.Add(add);
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
                return View(db.CompanySet.Where(x => x.CompanyId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Company edit)
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
                return View(db.CompanySet.Where(x => x.CompanyId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Company delete)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    delete = db.CompanySet.Where(x => x.CompanyId == id).FirstOrDefault();
                    db.CompanySet.Remove(delete);
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