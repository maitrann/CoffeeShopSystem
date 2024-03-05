using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class supplierUrl
    {
        public static string RegiterSupplier = "http://localhost:63566/api/SupplierAPI/RegiterSupplier";
        public static string checkExistEmail = "http://localhost:63566/api/SupplierAPI/checkExistEmail";
        public static string checkExistPhone = "http://localhost:63566/api/SupplierAPI/checkExistPhone";

    }
}