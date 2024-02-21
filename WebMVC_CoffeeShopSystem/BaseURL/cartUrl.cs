using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class cartUrl
    {
        public static string GetCart = "http://localhost:63566/api/CartAPI/GetCart";
        public static string UpdateInsertCart = "http://localhost:63566/api/CartAPI/UpdateInsertCart";

        public static string UpdateCart = "http://localhost:63566/api/CartAPI/UpdateCart";
        public static string DeleteCart = "http://localhost:63566/api/CartAPI/DeleteCart";
        public static string GetCartCheckout = "http://localhost:63566/api/CartAPI/GetCartCheckout";
        public static string quantityCartOfUser = "http://localhost:63566/api/CartAPI/quantityCartOfUser";
        public static string UpdateCartCheckout = "http://localhost:63566/api/CartAPI/UpdateCartCheckout";


    }
}