using First1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace First1.Controllers
{
    //[Authorize()]
    public class EmployeeController : Controller
    {
        private OurDbContext db = new OurDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {

                IList<Employee> employees = db.Employees.Include(c => c.Department).ToList();
                //List<Employee> employees = db.Employees.ToList();
                return View(employees);

            }
            else
            {
                return RedirectToAction("Login", "User");
            }
           


        }
        
        public ActionResult AddEmployee()
        {
            if (Session["Id"] != null)
            {

                ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            return View();

            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
       
        #region Add Employee
        [HttpPost]
        
        public ActionResult AddEmployee([Bind(Include = "Id,FirstName,LastName,CIN,DepartmentID")]Employee employee)
        {
            if (ModelState.IsValid)
            {
               
                    db.Employees.Add(employee);
                    db.SaveChanges();
               
                ModelState.Clear();
                ViewBag.Message = "Successfully.";
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);
            //return View(employee);
            return RedirectToAction("index"); 
        }
        #endregion
        public ActionResult Delete(int id)
        {
           
                Employee employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
            ViewBag.DepartmentID = new SelectList(db.Departments.Where(e => e.DepartmentID == employee.DepartmentID), "DepartmentID", "DepartmentName", employee.DepartmentID);
            return View(employee);
          
        }
        #region 
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
           
                
                //Employee employee =  db.employees.Find(id);
                db.Entry(employee).State = EntityState.Deleted;
                db.Employees.Remove(employee);
                    db.SaveChanges();
                
                //ViewBag.Message =  "successfully.";
            
            return RedirectToAction("Index");
        }
        #endregion

        public ActionResult Details(int id)
        {
           // Employee employee = db.Employees.Where(c => c.Id == id).FirstOrDefault();
            var employee = db.Employees.Find(id);
            //EmployeeDetails employee = db.Employees.Where(c=>c.Id==id).Select(m => new EmployeeDetails
            //{
            //    CIN = m.CIN,
            //    DepartmentName = m.Department.DepartmentName,
            //    FirstName=m.FirstName,
            //    Id=m.Id,
            //    LastName=m.LastName
            //}).First() ;

            if (employee == null)
                {
                    return HttpNotFound();
                }
            var d = db.Departments.Where(e => e.DepartmentID == employee.DepartmentID).FirstOrDefault();
            ViewBag.departmentName = d.DepartmentName.ToString() ;
            
            //ViewBag.DepartmentID = new (db.Departments.Where(e=>e.DepartmentID==employee.DepartmentID), "DepartmentID", "DepartmentName", employee.DepartmentID);
            return View(employee);
           
           
        }
        #region Edit
        
        #endregion
        public ActionResult Edit(int id)
        {
            
                Employee employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);
            return View(employee);
           
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