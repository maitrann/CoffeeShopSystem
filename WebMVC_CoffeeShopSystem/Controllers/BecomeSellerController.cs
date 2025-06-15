using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.Dao;
using WebMVC_CoffeeShopSystem.Utilities;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class BecomeSellerController : Controller
    {
        // GET: BecomeSeller
        public ActionResult Index()
        {
            return View();
        }
        public string checkExistEmail(string emailRegis)
        {
            bool flag = SupplierDao.Instance.checkExistEmail(emailRegis);
            if (flag == true)
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }
        public string checkExistPhone(string phoneRegis)
        {
            bool flag = SupplierDao.Instance.checkExistPhone(phoneRegis);
            if (flag == true)
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }
        public string RegiterSupplier(string title, string email, string phone, string address)
        {
            Supplier model = new Supplier()
            {
                title = title,
                email = email,
                phone = phone,
                address = address
            };
            Supplier flag = SupplierDao.Instance.RegiterSupplier(model);
            //SendMail(title, email, phone, address, flag.password);
            return "True";
        }
        private void SendMail(string title, string mailTo, string phone, string address, string password)
        {
            SendMailKit.SendRegisSeller(title, mailTo, phone, address, password);
        }
    }
}
