using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class reviewUrl
    {
        public static string GetReviewsOfProduct = "http://localhost:63566/api/ReviewAPI/GetReviewsOfProduct";
        public static string avgReviewOfProduct = "http://localhost:63566/api/ReviewAPI/avgReviewOfProduct";
        public static string countReviewOfProduct = "http://localhost:63566/api/ReviewAPI/countReviewOfProduct";


    }
}