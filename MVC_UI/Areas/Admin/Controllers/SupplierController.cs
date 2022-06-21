using BLL.Concrete;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class SupplierController : Controller
    {
        SupplierService supplierService = new SupplierService();
        public ActionResult Index()
        {
            return View(supplierService.GetList());
        }

        public ActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            try
            {
                bool result = supplierService.Any(x => x.CompanyName == supplier.CompanyName);
                if (result)
                {
                    TempData["message"] = "Bu Supplier zaten mevcut!";
                    return View(supplier);
                }
                else
                {
                    TempData["message"] = supplierService.Add(supplier);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return View();
            }
        }

        public ActionResult DeleteSupplier(Guid id)
        {
            try
            {
                TempData["message"] = supplierService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult DeleteForceSupplier(Guid id)
        {
            var deleted = supplierService.GetById(id);
            try
            {
                TempData["message"] = supplierService.RemoveForce(deleted);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult UpdateSupplier(Guid id)
        {
            var updated = supplierService.GetById(id);
            return View(updated);
        }
        [HttpPost]
        public ActionResult UpdateSupplier(Supplier supplier)
        {
            try
            {
                TempData["message"] = supplierService.Update(supplier);
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