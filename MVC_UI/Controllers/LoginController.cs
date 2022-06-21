using BLL.Concrete;
using DAL.Entity;
using MVC_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_UI.Controllers
{
    public class LoginController : Controller
    {
        AppUserService appUserService = new AppUserService();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUserVM loginUserVM)
        {
            if (ModelState.IsValid)
            {
                bool result = appUserService.Any(x => x.UserName == loginUserVM.UserName && x.Password == loginUserVM.Password);
                if (result)
                {
                    AppUser user = appUserService.GetDefault(x => x.UserName == loginUserVM.UserName).FirstOrDefault();
                    FormsAuthentication.SetAuthCookie(user.UserName, true); //create cookies
                    Session["login"] = user;
                    if (user.UserName == "enes")
                    {
                        return RedirectToAction("Index", "Admin/Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["error"] = $"Username/Password is incorrect. Please check your information..";
                    return View(loginUserVM);
                }
            }
            else
            {
                return View(loginUserVM);
            }
        }
    }
}