using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class productUrl
    {
        #region User
        public static string getProducts = "http://localhost:63566/api/ProductAPI/GetProducts";
        public static string getDetailsProduct = "http://localhost:63566/api/ProductAPI/GetDetailsProduct";
        public static string getBlogs = "";
        public static string getDetailsBlog = "";
        public static string getWatchList = "";
        public static string getProductsOfSupp = "";
        #endregion
    }
}