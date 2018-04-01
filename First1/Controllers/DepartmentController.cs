using First1.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First1.Controllers
{
    //[Authorize]
    public class DepartmentController : Controller
    {
        private OurDbContext db = new OurDbContext();
        // GET: Department
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {
                //var s = .Include(c);
                return View(db.Departments);


        }
            else
            {
                return RedirectToAction("Login", "User");
    }
}

        #region AddDepartment

        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            if (Session["Id"] != null)
            {
                if (ModelState.IsValid)
            {
               
                    db.Departments.Add(department);
                    db.SaveChanges();
               
                ModelState.Clear();
                ViewBag.Message = department.DepartmentName + " "+" successfully.";
            }
            return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        #endregion
      
        #region Delete
        public ActionResult Delete(int? id)
        {
           
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        // Get partial view
        public ActionResult EmplyeeByDepartment(IList<Employee> employees)
        {

            //IList<Employee> employees = emp.EmpDep;
            //List<Employee> employees = db.Employees.ToList();
            return PartialView(employees);


        }
        public ActionResult Details(int? id)
        {

            Department department = db.Departments.Where(d=>d.DepartmentID==id).Include(d=>d.EmpDep).FirstOrDefault();
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        #region Edit
        public ActionResult Edit(int? id)
        {
           
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [HttpPost]
      
        public ActionResult Edit([Bind(Include = "DepartmentID,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }
        #endregion
    }
}