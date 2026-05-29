namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class accountUrl
    {
        public static string CheckAccountExistUsername = stringUrl.Build("api/AccountAPI/CheckAccountExistUsername");
        public static string CheckAccountExistEmail = stringUrl.Build("api/AccountAPI/CheckAccountExistEmail");
        public static string CheckAccountExistPhone = stringUrl.Build("api/AccountAPI/CheckAccountExistPhone");
        public static string SignUpAccount = stringUrl.Build("api/AccountAPI/SignUpAccount");
        public static string SignInAccount = stringUrl.Build("api/AccountAPI/SignInAccount");
    }
}
