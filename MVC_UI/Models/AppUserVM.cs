using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_UI.Models
{
    public class AppUserVM
    {
        [Required(ErrorMessage = "Username is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required!")]
        [Compare("Password", ErrorMessage = "Passwords are not the same!")]
        public string ConfirmPassword { get; set; }
        [EmailAddress(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
    }
}