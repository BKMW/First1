using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace First1.Models
{
    public class OurDbContext:DbContext
    {
        public DbSet<User> user { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
    
}