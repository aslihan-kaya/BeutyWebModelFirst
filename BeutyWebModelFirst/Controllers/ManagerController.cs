using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeutyWebModelFirst.Models;

namespace BeutyWebModelFirst.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        Model1Container1 db = new Model1Container1();
        public ActionResult Index()
        {
            return View(db.ManagerSet.ToList());
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Manager add)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    db.ManagerSet.Add(add);
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
                return View(db.ManagerSet.Where(x => x.ManagerId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Manager edit)
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
                return View(db.ManagerSet.Where(x => x.ManagerId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Manager delete)
        {
            try
            {
                using (Model1Container1 db = new Model1Container1())
                {
                    delete = db.ManagerSet.Where(x => x.ManagerId == id).FirstOrDefault();
                    db.ManagerSet.Remove(delete);
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