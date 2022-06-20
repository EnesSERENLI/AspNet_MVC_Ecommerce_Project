using BLL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_UI.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        public ActionResult Details(Guid id)
        {
            var result = productService.GetById(id);
            if (result != null)
            {                
                return View(result); 
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
    }
}