using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeutyWebModelFirst.Models;

namespace BeutyWebModelFirst.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        Model1Container1 db = new Model1Container1();
        public ActionResult Index()
        {
            return View(db.BankSet.ToList());
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Bank add)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    db.BankSet.Add(add);
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
                return View(db.BankSet.Where(x => x.BankId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Bank edit)
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
                return View(db.BankSet.Where(x => x.BankId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Bank delete)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    delete = db.BankSet.Where(x => x.BankId == id).FirstOrDefault();
                    db.BankSet.Remove(delete);
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