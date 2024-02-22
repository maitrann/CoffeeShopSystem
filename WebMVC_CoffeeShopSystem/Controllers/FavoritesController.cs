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
            idAccount = "7";
            ViewBag.lstFv = WatchListDao.Instance.GetWatchList(idAccount.AsInt());
            return View();
        }
        public string AddToWatchList(int idProduct)
        {
            int idAccount = 7;
            WatchList model = new WatchList();
            model.idProduct = idProduct;
            model.idAccount = idAccount;
            model.createDate = DateTime.Now;
            bool add = WatchListDao.Instance.InsertWatchList(model);
            string res =add.ToString();
            return res;
        }
        public void RemoveToWatchList(int id)
        {
            WatchListDao.Instance.RemoveWatchList(id);
        }

    }
}