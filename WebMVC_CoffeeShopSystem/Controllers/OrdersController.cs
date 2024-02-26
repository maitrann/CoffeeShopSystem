using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using WebMVC_CoffeeShopSystem.Dao;
using WebMVC_CoffeeShopSystem.Repositories;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index(string checkout = null)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                var idAccount = reqCookies["userId"].ToString().AsInt();
                if (checkout != null)
                {
                    ViewBag.msgCheckout = "true";
                }
                else
                {
                    ViewBag.msgCheckout = "false";
                }
                ViewBag.quantityCart = CartDao.Instance.quantityCartOfUser(idAccount);
                ViewBag.lstInvoice = InvoiceDao.Instance.GetAllInvoice(idAccount);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Signin");
            }

        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                var idAccount = reqCookies["userId"].ToString().AsInt();
                ViewBag.lstInvoiceDetails = InvoiceDao.Instance.GetInvoiceDetails(idAccount, id);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Signin");

            }

        }
    }
}
