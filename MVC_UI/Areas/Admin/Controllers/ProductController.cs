using BLL.Concrete;
using Common;
using DAL.Entity;
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

        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase fileImage)
        {
            try
            {
                bool result = productService.Any(x => x.ID == product.ID);
                if (result)
                {
                    TempData["error"] = "This product is already exist!";
                    return View(product);
                }
                else
                {
                    product.ProductImagePath = ImageUploader.UploadImage("~/Content/image/product/", fileImage);
                    TempData["message"] = productService.Add(product);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }
    }
}