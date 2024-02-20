using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.Repositories;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            int idAccount = 7;
            ViewBag.lstCart = CartDao.Instance.getCart(idAccount);
            return View();
        }
        public void AddToCart(int idProduct, int Amount, decimal Price)
        {
            Cart model = new Cart();
            model.idAccount = 7;
            model.idProduct = idProduct;
            model.Amount = Amount;
            model.Price = Price;
            model.Status = true;
            CartDao.Instance.UpdateInsertCart(model);
        }
        public void UpdateCart(int idCart, int amount, decimal? price)
        {
            CartDao.Instance.UpdateCart(idCart, amount, price);
        }
        public void DeleteCart(int idCart)
        {
            CartDao.Instance.DeleteCart(idCart);
        }
        public JsonResult CartIntroVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            var callVSel = VoucherDao.Instance.CartIntroVoucherToSelect(userCreate, priceCartSupp);
            if (callVSel != null)
            {
                var parseJson = Json(callVSel, JsonRequestBehavior.AllowGet);
                return parseJson;
            }
            else
            {
                return null;
            }
        }
        public JsonResult CartAutoOneVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            var callVSel = VoucherDao.Instance.CartAutoOneVoucherToSelect(userCreate, priceCartSupp);
            if (callVSel != null)
            {
                var parseJson = Json(callVSel, JsonRequestBehavior.AllowGet);
                return parseJson;
            }
            else
            {
                return null;
            }
        }
        public ActionResult partialModalSelectVoucherInCart(int userCreate, decimal? priceCompareCondition)
        {
            ViewBag.lstVoucherCafena = VoucherDao.Instance.CartGetVoucherToSelect(userCreate, priceCompareCondition);
            ViewBag.priceCompareConditionCafena = priceCompareCondition;
            ViewBag.callAutoVou = VoucherDao.Instance.CartAutoOneVoucherToSelect(userCreate, priceCompareCondition);

            return PartialView();
        }
        public ActionResult partialModalSelectVoucherOfSuppInCart(int userCreate, decimal? priceCompareCondition)
        {
            ViewBag.lstVoucher = VoucherDao.Instance.CartGetVoucherToSelect(userCreate, priceCompareCondition);
            ViewBag.priceCompareCondition = priceCompareCondition;
            ViewBag.callAutoVou = VoucherDao.Instance.CartAutoOneVoucherToSelect(userCreate, priceCompareCondition);
            return PartialView();
        }
    }
}