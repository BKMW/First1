using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace First1.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Department is required.")]
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }
        public IList<Employee> EmpDep { get; set; }


    }
}