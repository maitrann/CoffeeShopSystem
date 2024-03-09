using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC_CoffeeShopSystem.Dao;

namespace WebMVC_CoffeeShopSystem.Areas.Supplier.Controllers
{
    public class LoginController : Controller
    {
        // GET: Supplier/Login
        public ActionResult Index()
        {
            return View();
        }
        public string CheckEmailSupplier(string email)
        {
            bool flag = SupplierDao.Instance.checkExistEmail(email);
            if (flag == true)
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }
        public string CheckPassSupplier(string email, string password)
        {
            bool flag = SupplierDao.Instance.checkPasswordWithEmail(email, password);
            if (flag == true)
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }
        public string GetSupplierLogin(string email,string password)
        {
            var log = SupplierDao.Instance.getSupplierLog(email, password);
            if (log != null)
            {
                HttpCookie supplierInfo = new HttpCookie("supplierInfo");
                supplierInfo["supplierId"] = log.id.ToString();
                supplierInfo["supplierEmail"] = log.email.ToString();
                Response.Cookies.Add(supplierInfo);
                return "True";
            }
            else
            {
                return "False";
            }
        }
    }
}