using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.Dao;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class FavoritesController : Controller
    {
        // GET: Favorites
        public ActionResult Index(string idAccount = null)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                idAccount = reqCookies["userId"].ToString();
                ViewBag.lstFv = WatchListDao.Instance.GetWatchList(idAccount.AsInt());
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Signin");
            }

        }
        public string AddToWatchList(int idProduct)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                int idAccount = reqCookies["userId"].ToString().AsInt();
                WatchList model = new WatchList();
                model.idProduct = idProduct;
                model.idAccount = idAccount;
                model.createDate = DateTime.Now;
                bool add = WatchListDao.Instance.InsertWatchList(model);
                string res = add.ToString();
                return res;
            }
            else
            {
                return "NotSignin";
            }

        }
        public void RemoveToWatchList(int id)
        {
            WatchListDao.Instance.RemoveWatchList(id);
        }

    }
}