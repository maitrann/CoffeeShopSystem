using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI_CoffeeShop.Models.ModelView;
using WebMVC_CoffeeShopSystem.Repositories;
using WebMVC_CoffeeShopSystem.Dao;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        dynamic callProductDao = ProductDao.Instance;
        dynamic callCategoryDao = CategoryDao.Instance;
        dynamic callReviewDao = ReviewDao.Instance;
        dynamic callSupplierDao = SupplierDao.Instance;

        public ActionResult Index()
        {
            ViewBag.lstProd = callProductDao.getProducts();
            ViewBag.menuCate = callCategoryDao.GetMenuCategory();
            return View();
        }
        public ActionResult Details(int? idProd)
        {
            if (idProd != null)
            {
                ProductView details = callProductDao.GetDetailsProduct(idProd);
                if (details != null)
                {
                    ViewBag.detailsProd = details;
                    ViewBag.relatedProducts = ((List<ProductView>)callProductDao.getProducts())
                        .Where(p => p.id != details.id)
                        .Take(4)
                        .ToList();
                    if (details.idSupplier.HasValue)
                    {
                        ViewBag.supplierProfile = callSupplierDao.GetSupplierById(details.idSupplier.Value);
                    }
                    ViewBag.avgReview = callReviewDao.avgReviewOfProduct(idProd);
                    ViewBag.countReview =callReviewDao.countReviewOfProduct(idProd);
                    ViewBag.lstReview = callReviewDao.GetReviewsOfProduct(idProd);
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult popupProd(int? idProd)
        {
            ProductView details = callProductDao.GetDetailsProduct(idProd);
            ViewBag.detailsProd = details;
            return PartialView();
        }

        public ActionResult SearchProductsByKeyWord(string keyword)
        {
            ViewBag.lstProdSearch = callProductDao.SearchProductsByKeyWord(keyword);
            return PartialView();
        }
        public ActionResult SearchProductsByCategory(string lsIdCategory)
        {
            ViewBag.lstProdSearch = callProductDao.SearchProductsByCategory(lsIdCategory);
            return PartialView("SearchProductsByKeyWord");
        }
        public ActionResult SearchProductsByPrice(int typePrice)
        {
            ViewBag.lstProdSearch = callProductDao.SearchProductsByPrice(typePrice);
            return PartialView("SearchProductsByKeyWord");
        }
    }
}
