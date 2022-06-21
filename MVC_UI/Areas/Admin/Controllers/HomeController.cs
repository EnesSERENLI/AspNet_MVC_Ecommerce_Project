using BLL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_UI.Areas.Admin.Controllers
{
    //[Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        ProductService productService = new ProductService();
        public ActionResult Index()
        {
            return View(productService.GetList());
        }
    }
}