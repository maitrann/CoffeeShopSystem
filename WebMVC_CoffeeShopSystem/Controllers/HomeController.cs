using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMVC_CoffeeShopSystem.Repositories;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["shortMessageSignin"] != null)
            {
                ViewBag.shortMessageSignin = "true";
                TempData.Remove("shortMessageSignin");
            }
            return View();
        }

    }
}
