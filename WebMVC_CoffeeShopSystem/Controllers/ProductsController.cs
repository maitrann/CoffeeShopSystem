﻿using Newtonsoft.Json;
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

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        dynamic callProductDao = ProductDao.Instance;
        public ActionResult Index()
        {
            ViewBag.lstProd = callProductDao.getProducts();
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
                    return View();
                }
                else
                {
                    return Redirect("http://localhost:52519");
                }
            }
            else
            {
                return Redirect("http://localhost:52519");
            }
        }
        public ActionResult popupProd(int? idProd)
        {
            ProductView details = callProductDao.GetDetailsProduct(idProd);
            ViewBag.detailsProd = details;
            return PartialView();
        }
    }
}