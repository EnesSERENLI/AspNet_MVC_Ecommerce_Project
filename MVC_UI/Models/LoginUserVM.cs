using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_UI.Models
{
    public class LoginUserVM
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string Password { get; set; }
    }
}