using BLL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_UI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        SupplierService supplierService = new SupplierService();
        SubCategoryService subCategoryService = new SubCategoryService();
        public ActionResult Index()
        {
            return View(productService.GetList()); //All products..
        }

        public ActionResult AddProduct()
        {
            ViewBag.Supplier = supplierService.GetDefault(x=>x.Status == Core.Enums.Status.Active);
            ViewBag.SubCategories = subCategoryService.GetDefault(x => x.Status == Core.Enums.Status.Active);
            return View();
        }
    }
}