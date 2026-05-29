namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class cartUrl
    {
        public static string GetCart = stringUrl.Build("api/CartAPI/GetCart");
        public static string UpdateInsertCart = stringUrl.Build("api/CartAPI/UpdateInsertCart");
        public static string UpdateCart = stringUrl.Build("api/CartAPI/UpdateCart");
        public static string DeleteCart = stringUrl.Build("api/CartAPI/DeleteCart");
        public static string GetCartCheckout = stringUrl.Build("api/CartAPI/GetCartCheckout");
        public static string quantityCartOfUser = stringUrl.Build("api/CartAPI/quantityCartOfUser");
        public static string UpdateCartCheckout = stringUrl.Build("api/CartAPI/UpdateCartCheckout");
    }
}
