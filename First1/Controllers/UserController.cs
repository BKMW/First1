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
        private OurDbContext db = new OurDbContext();
        
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        #region Register
        //[Route("Home/Register")]
        public ActionResult Register()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Register(User user)
        {
            var SearchUsername = db.Users.Where(x => x.Username == user.Username).SingleOrDefault();
            var SearchEmail = db.Users.Where(x => x.Email == user.Email).SingleOrDefault();

            if (ModelState.IsValid&& SearchUsername == null && SearchEmail == null)
            {
               
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                
                //ModelState.Clear();
                //ViewBag.Message = user.FirstName + "" + user.LastName + " successfully registered.";
            }
            if(SearchEmail != null)
            {
                ViewBag.Message = " Email is found .";

            }
            if (SearchEmail != null)
            {
                ViewBag.Message = " Username is found .";
            }
            return View();
        }
        #endregion
        #region Login
        //[Route("Home/Login")]
        public ActionResult Login()
        {
            return View();
        }
      
       
        [HttpPost]
        public ActionResult Login(User user)
        {

            //User usr = db.Users.Find(1);
            try
            {
                var usr = db.Users.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    Session["Id"] = usr.Id.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoginIn");

                }
               
            } catch {

                ViewBag.Message = "Login or Passwor is false.";

            }

            return View();

        }
        #endregion
        public ActionResult LoginIn()
        {
            if (Session["Id"] != null)
            {
               // return View();
                return RedirectToAction("Index","Employee");
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}