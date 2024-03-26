using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class invoiceUrl
    {
        public static string GetAllInvoice = "http://localhost:63566/api/InvoiceAPI/GetAllInvoice";
        public static string GetInvoiceDetails = "http://localhost:63566/api/InvoiceAPI/GetInvoiceDetails";
        public static string InsertInvoice = "http://localhost:63566/api/InvoiceAPI/InsertInvoice";

        public static string GetInvoiceOfSupplier = "http://localhost:63566/api/InvoiceAPI/GetInvoiceOfSupplier";

    }
}