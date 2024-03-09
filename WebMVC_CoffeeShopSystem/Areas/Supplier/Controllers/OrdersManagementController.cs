using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC_CoffeeShopSystem.Areas.Supplier.Controllers
{
    public class OrdersManagementController : Controller
    {
        // GET: Supplier/Orders
        public ActionResult Index()
        {
            return View();
        }
    }
}