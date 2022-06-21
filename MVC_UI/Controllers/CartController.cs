using BLL.Concrete;
using Common;
using DAL.Entity;
using MVC_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_UI.Controllers
{
    public class CartController : Controller
    {
        ProductService productService = new ProductService();
        public ActionResult AddToCart(Guid id)
        {
            try
            {
                Product product = productService.GetById(id);
                Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

                CartItem ci = new CartItem();
                ci.Id = product.ID;
                ci.Price = product.UnitPrice;
                ci.ProductName = product.ProductName;
                c.AddItem(ci);
                Session["scart"] = c;
                return RedirectToAction("Index","Home");
            }
            catch (Exception)
            {
                TempData["error"] = $"{id} No corresponding product was found!";
                return View();
            }
        }

        public ActionResult MyCart()
        {
            if (Session["scart"] != null)
            {
                return View();
            }
            else
            {
                TempData["error"] = "sepetinizde ürün bulunmamaktadır!";
                return View();
            }

        }

        [Authorize(Roles ="admin,member,moderator")]
        public ActionResult ComplateCart() //Order Complate
        {
            Cart cart = Session["scart"] as Cart;
            AppUser user = Session["login"] as AppUser;
            foreach (var item in cart.myCart)
            {
                Product product = productService.GetById(item.Id);
                product.UnitsInStock -= Convert.ToInt16(item.Quantity);
                productService.Update(product);

            }
            Random rnd = new Random();
            ViewBag.OrderNumber = rnd.Next(100000, 1000000);
            string message = $"<h2 style='color:green'>Hello!!</h2> </br> We have received your order number <h2><strong>{ViewBag.OrderNumber}</strong></h2> Your order will be on its way to be delivered as soon as possible.";
            MailSender.SendMail(user.Email, "Order Information", message);
            Session.Remove("scart");
            return View();
        }

    }
}