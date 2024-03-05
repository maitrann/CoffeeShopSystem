using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC_CoffeeShopSystem.Dao;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class BecomeSellerController : Controller
    {
        // GET: BecomeSeller
        public ActionResult Index()
        {
            return View();
        }
        public bool checkExistEmail(string emailRegis)
        { 
            return SupplierDao.Instance.checkExistEmail(emailRegis);
        }
        public bool checkExistPhone(string phoneRegis)
        {
            return SupplierDao.Instance.checkExistPhone(phoneRegis);
        }

    }
}