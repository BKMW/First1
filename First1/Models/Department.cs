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
        public int Id { get; set; }
        [Required(ErrorMessage = "Department is required.")]
        public string DepârtmentName { get; set; }
       
      
    }
}