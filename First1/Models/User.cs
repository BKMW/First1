using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace First1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage ="First Name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Name is required.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Name is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}