namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class googleAuthUrl
    {
        public static string connectGoogleAuth = stringUrl.Build("api/GoogleAccountAPI/connectGoogleAuth");
        public static string GoogleLoginCallBack = stringUrl.Build("api/GoogleAccountAPI/GoogleLoginCallBack");
    }
}
