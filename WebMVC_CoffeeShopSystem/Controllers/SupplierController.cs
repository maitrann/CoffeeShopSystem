using System.Web.Mvc;
using WebMVC_CoffeeShopSystem.Dao;
using WebMVC_CoffeeShopSystem.Repositories;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class SupplierController : Controller
    {
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Products");
            }

            var supplier = SupplierDao.Instance.GetSupplierById(id.Value);
            if (supplier == null)
            {
                return RedirectToAction("Index", "Products");
            }

            ViewBag.supplier = supplier;
            ViewBag.lstProd = ProductDao.Instance.SearchProductsBySupplier(id.Value);
            ViewBag.menuCate = CategoryDao.Instance.GetMenuCategory();

            return View();
        }
    }
}
