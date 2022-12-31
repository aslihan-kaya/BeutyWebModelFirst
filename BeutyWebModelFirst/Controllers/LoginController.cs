using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BeutyWebModelFirst.Models;
using Microsoft.SqlServer.Server;


namespace BeutyWebModelFirst.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (Model1Container1 db = new Model1Container1())
            {
                var result = db.MemberSet.Where(x => x.MemberName == user.MemberName && x.MemberPassword == user.MemberPassword);
                if (result.Count() != 0)
                {
                    FormsAuthentication.SetAuthCookie(user.MemberName, false);
                    //Session["userId]=user.Username;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["msg"] = "hatalı";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}