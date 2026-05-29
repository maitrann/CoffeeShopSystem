namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class invoiceUrl
    {
        public static string GetAllInvoice = stringUrl.Build("api/InvoiceAPI/GetAllInvoice");
        public static string GetInvoiceDetails = stringUrl.Build("api/InvoiceAPI/GetInvoiceDetails");
        public static string InsertInvoice = stringUrl.Build("api/InvoiceAPI/InsertInvoice");
        public static string GetInvoiceOfSupplier = stringUrl.Build("api/InvoiceAPI/GetInvoiceOfSupplier");
    }
}
