using First1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First1.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.department.ToList());
            }

        }

        public ActionResult AddDepartment()
        {
            return View();
        }
        #region Register
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.department.Add(department);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = department.DepârtmentName + " successfully.";
            }
            return View();
        }
        #endregion
    }
}