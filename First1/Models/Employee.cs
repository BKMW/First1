using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace First1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "CIN Name is required.")]
        public string CIN { get; set; }
        //[Required(ErrorMessage = "Department Name is required.")]
        
       
      
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        //public string DepartmentName { get; set; }

    }
}