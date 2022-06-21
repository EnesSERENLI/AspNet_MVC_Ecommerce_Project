using BLL.Concrete;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_UI.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        SubCategoryService subCategoryService = new SubCategoryService();
        CategoryService categoryService = new CategoryService();
        public ActionResult Index()
        {
            return View(subCategoryService.GetList());
        }

        public ActionResult AddSubCategory()
        {
            ViewBag.Categories = categoryService.GetDefault(x => x.Status == Core.Enums.Status.Active || x.Status == Core.Enums.Status.Updated);
            return View();
        }
        [HttpPost]
        public ActionResult AddSubCategory(SubCategory subCategory)
        {
            try
            {
                bool result = subCategoryService.Any(x => x.SubCategoryName == subCategory.SubCategoryName);
                if (result)
                {
                    TempData["message"] = "Bu Subcategory zaten mevcut!";
                    return View(subCategory);
                }
                else
                {
                    TempData["message"] = subCategoryService.Add(subCategory);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return View();
            }
        }

        public ActionResult DeleteSubCategory(Guid id)
        {
            try
            {
                TempData["message"] = subCategoryService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult DeleteForceSubCategory(Guid id)
        {
            var deleted = subCategoryService.GetById(id);
            try
            {
                TempData["message"] = subCategoryService.RemoveForce(deleted);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult UpdateSubCategory(Guid id)
        {
            ViewBag.Categories = categoryService.GetDefault(x => x.Status == Core.Enums.Status.Active || x.Status == Core.Enums.Status.Updated);
            var updated = subCategoryService.GetById(id);
            return View(updated);
        }
        [HttpPost]
        public ActionResult UpdateSubCategory(SubCategory subCategory)
        {
            try
            {
                TempData["message"] = subCategoryService.Update(subCategory);
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