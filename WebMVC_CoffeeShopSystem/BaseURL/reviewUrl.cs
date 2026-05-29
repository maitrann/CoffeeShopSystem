namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class reviewUrl
    {
        public static string GetReviewsOfProduct = stringUrl.Build("api/ReviewAPI/GetReviewsOfProduct");
        public static string avgReviewOfProduct = stringUrl.Build("api/ReviewAPI/avgReviewOfProduct");
        public static string countReviewOfProduct = stringUrl.Build("api/ReviewAPI/countReviewOfProduct");
    }
}
