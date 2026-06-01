namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class productUrl
    {
        public static string getProducts = stringUrl.Build("api/ProductAPI/GetProducts");
        public static string getDetailsProduct = stringUrl.Build("api/ProductAPI/GetDetailsProduct");
        public static string SearchProductsByKeyWord = stringUrl.Build("api/ProductAPI/SearchProductsByKeyWord");
        public static string SearchProductsByCategory = stringUrl.Build("api/ProductAPI/SearchProductsByCategory");
        public static string SearchProductsByPrice = stringUrl.Build("api/ProductAPI/SearchProductsByPrice");
        public static string SearchProductsBySupplier = stringUrl.Build("api/ProductAPI/SearchProductsBySupplier");
    }
}
