using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.Repositories;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                var userId = reqCookies["userId"].ToString();
                ViewBag.lstCart = CartDao.Instance.getCart(userId.AsInt());
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Signin");
            }
        }
        public string AddToCart(int idProduct, int Amount, decimal Price)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                Cart model = new Cart();
                model.idAccount = reqCookies["userId"].ToString().AsInt();
                model.idProduct = idProduct;
                model.Amount = Amount;
                model.Price = Price;
                model.Status = true;
                CartDao.Instance.UpdateInsertCart(model);
                return "True";
            } else
            {
                return "False";
            }
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