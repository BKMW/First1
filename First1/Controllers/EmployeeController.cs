using First1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.employees.ToList());
            }
            
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        #region Register
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.employees.Add(employee);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = employee.FirstName + "successfully.";
            }
            return View();
        }
        #endregion
        public ActionResult Delete(int id)
        {
            using (OurDbContext db = new OurDbContext())
            {
                Employee employee = db.employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
        }
        #region 
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
           
                using (OurDbContext db = new OurDbContext())
                {
                //Employee employee =  db.employees.Find(id);
                db.Entry(employee).State = EntityState.Deleted;
                db.employees.Remove(employee);
                    db.SaveChanges();
                }
                //ViewBag.Message =  "successfully.";
            
            return RedirectToAction("Index");
        }
        #endregion

        public ActionResult Details(int id)
        {

            using (OurDbContext db = new OurDbContext())
            {
                Employee employee = db.employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
           
        }

        public ActionResult Edit(int id)
        {
            using (OurDbContext db = new OurDbContext())
            {
                Employee employee = db.employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
        }
        #region Register
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(employee);
        }
        #endregion
    }
}