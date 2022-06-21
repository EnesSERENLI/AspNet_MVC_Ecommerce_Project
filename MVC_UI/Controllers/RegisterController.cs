using BLL.Concrete;
using DAL.Entity;
using MVC_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_UI.Controllers
{
    public class RegisterController : Controller
    {
        AppUserService appUserService = new AppUserService();
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUserVM appUserVM)
        {
            if (ModelState.IsValid)
            {
                var result = appUserService.Any(x => x.UserName == appUserVM.UserName && x.Email == appUserVM.Email);
                if (result)
                {
                    TempData["info"] = "This User already exist!";
                    return View();
                }
                else
                {
                    AppUser user = new AppUser();
                    user.UserName = appUserVM.UserName;
                    user.Email = appUserVM.Email;
                    user.Password = appUserVM.Password;
                    var message = appUserService.Add(user);
                    TempData["info"]=message;

                    //Mail Sender
                    return RedirectToAction("Pending");
                }
            }
            else
            {
                return View(appUserVM);
            }
        }


    }
}