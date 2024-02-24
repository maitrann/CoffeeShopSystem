using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class accountUrl
    {
        public static string CheckAccountExistUsername = "http://localhost:63566/api/AccountAPI/CheckAccountExistUsername";
        public static string CheckAccountExistEmail = "http://localhost:63566/api/AccountAPI/CheckAccountExistEmail";
        public static string CheckAccountExistPhone = "http://localhost:63566/api/AccountAPI/CheckAccountExistPhone";
        public static string SignUpAccount = "http://localhost:63566/api/AccountAPI/SignUpAccount";
        public static string SignInAccount = "http://localhost:63566/api/AccountAPI/SignInAccount";

    }
}