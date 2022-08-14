using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBMS_PROJECT.Models;

namespace DBMS_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        Library_Management_SystemEntities db = new Library_Management_SystemEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Signup_List()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User user)
        {
            if (db.Users.Any(x => x.UserName == user.UserName))
            {
                ViewBag.Notification = "This Account is Already Exist";
                return View();

            }
            else
            {
                user.RePassword = user.Password;
                db.Users.Add(user);
                db.SaveChanges();
                //Session["idusSS"] = user.id.ToString();
                //Session["Usernamess"] = user.UserName.ToString();
                //Session["Password"] = user.Password.ToString();
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var login = db.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password) && x.RePassword.Equals(user.RePassword)).FirstOrDefault();
         
            if (login != null)
            {
                Session["IdUsSS"] = user.id.ToString();
                Session["UsernameSS"] = user.UserName.ToString();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong Username Or Password";
            }

            return View();
        }
    }
}