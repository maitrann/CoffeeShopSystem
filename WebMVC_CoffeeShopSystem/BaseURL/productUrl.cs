using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class productUrl
    {
        public static string getProducts = "http://localhost:63566/api/ProductAPI/GetProducts";
        public static string getDetailsProduct = "http://localhost:63566/api/ProductAPI/GetDetailsProduct";
        public static string SearchProductsByKeyWord = "http://localhost:63566/api/ProductAPI/SearchProductsByKeyWord";
        public static string SearchProductsByCategory = "http://localhost:63566/api/ProductAPI/SearchProductsByCategory";
        public static string SearchProductsByPrice = "http://localhost:63566/api/ProductAPI/SearchProductsByPrice";


    }
}