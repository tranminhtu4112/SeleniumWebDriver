using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeleniumwebdriverTest.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public static Boolean checkPassword(String password)
        {
            if (password.Length >= 6 && password.Length <= 24)
                return true;
            return false;
        }
        public ActionResult Index(String error)
        {
            if(error == null)
                ViewBag.error = null;
            else
                ViewBag.error = error;
            return View();
        }

        [HttpPost]
        public ActionResult Submit(String email, String password)
        {
            if(checkPassword(password))
                return RedirectToAction("Index", "Login", new { error = "success" });
            return RedirectToAction("Index", "Login", new { error = "failed" });
        }
    }
}