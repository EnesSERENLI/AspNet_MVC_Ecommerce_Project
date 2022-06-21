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

        //Add
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
                    product.ProductImagePath = ImageUploader.UploadImage("~/Content/image/product/", fileImage); //ImageName
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
        //Delete
        public ActionResult DeleteProduct(Guid id)
        {
            try
            {
                TempData["message"] = productService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        //DeleteForce
        public ActionResult DeleteForceProduct(Guid id)
        {
            try
            {
                var deleted = productService.GetById(id);
                if (deleted != null)
                {
                    TempData["message"] = productService.RemoveForce(deleted);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "Product not found!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        //Update
        public ActionResult UpdateProduct(Guid id)
        {
            ViewBag.Supplier = supplierService.GetDefault(x => x.Status == Core.Enums.Status.Active);
            ViewBag.SubCategories = subCategoryService.GetDefault(x => x.Status == Core.Enums.Status.Active);
            var updated = productService.GetById(id);
            return View(updated);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            try
            {
                TempData["message"] = productService.Update(product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return View();
            }
        }
    }
}