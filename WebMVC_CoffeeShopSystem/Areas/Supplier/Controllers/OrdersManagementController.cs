using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC_CoffeeShopSystem.Dao;

namespace WebMVC_CoffeeShopSystem.Areas.Supplier.Controllers
{
    public class OrdersManagementController : Controller
    {
        // GET: Supplier/Orders
        public ActionResult Index()
        {
            HttpCookie reqCookies = Request.Cookies["supplierInfo"];
            if(reqCookies != null)
            {
                ViewBag.lstOrder = InvoiceDao.Instance.GetInvoiceOfSupplier(int.Parse(reqCookies["supplierId"]));
                return View();
            }
            return Redirect("/Supplier/Login");
        }
    }
}