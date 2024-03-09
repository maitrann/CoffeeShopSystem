using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC_CoffeeShopSystem.Areas.Supplier.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Supplier/Dashboard
        public ActionResult Index()
        {
            HttpCookie reqCookies = Request.Cookies["supplierInfo"];
            if (reqCookies != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Supplier/Login");
            }
        }
    }
}