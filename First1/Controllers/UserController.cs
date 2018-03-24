using First1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        #region Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.user.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.FirstName + "" + user.LastName + "successfully registered.";
            }
            return View();
        }
        #endregion
        public ActionResult Login()
        {
            return View();
        }
        #region Login
        [HttpPost]
        public ActionResult Login(User user)
        {
           
                using (OurDbContext db = new OurDbContext())
                {
                var usr = db.user.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    Session["Id"] = usr.Id.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoginIn");

                }
                else
                {
                    ModelState.AddModelError("","username or Password is wrong.");
                }
            }
               
            
            return View();
        }
        #endregion
        public ActionResult LoginIn()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }

    }
}