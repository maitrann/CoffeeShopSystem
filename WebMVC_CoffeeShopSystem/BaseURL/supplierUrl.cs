using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class supplierUrl
    {
        public static string RegiterSupplier = stringUrl.BaseURL + "api/SupplierAPI/RegiterSupplier";
        public static string checkExistEmail = stringUrl.BaseURL + "api/SupplierAPI/checkExistEmail";
        public static string checkExistPhone = stringUrl.BaseURL + "api/SupplierAPI/checkExistPhone";
        public static string checkPasswordWithEmail = stringUrl.BaseURL + "api/SupplierAPI/checkPasswordWithEmail";
        public static string getSupplierLog = stringUrl.BaseURL + "api/SupplierAPI/getSupplierLog";

    }
}