namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class supplierUrl
    {
        public static string RegiterSupplier = stringUrl.Build("api/SupplierAPI/RegiterSupplier");
        public static string checkExistEmail = stringUrl.Build("api/SupplierAPI/checkExistEmail");
        public static string checkExistPhone = stringUrl.Build("api/SupplierAPI/checkExistPhone");
        public static string checkPasswordWithEmail = stringUrl.Build("api/SupplierAPI/checkPasswordWithEmail");
        public static string getSupplierLog = stringUrl.Build("api/SupplierAPI/getSupplierLog");
        public static string GetSupplierById = stringUrl.Build("api/SupplierAPI/GetSupplierById");
    }
}
