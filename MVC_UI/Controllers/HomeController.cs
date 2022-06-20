using BLL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_UI.Controllers
{
    public class HomeController : Controller
    {
        ProductService productService = new ProductService();
        public ActionResult Index()
        {
            var result = productService.GetDefault(x => x.Status == Core.Enums.Status.Active).ToList();
            return View(result);
        }
    }
}