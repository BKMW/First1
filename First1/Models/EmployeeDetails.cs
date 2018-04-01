using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace First1.Models
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CIN { get; set; }
        public string DepartmentName { get; set; }
    }
}