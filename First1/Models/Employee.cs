using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace First1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "CIN Name is required.")]
        public string CIN { get; set; }
        //[Required(ErrorMessage = "Department Name is required.")]
        //public Department Department { get; set; }


    }
}