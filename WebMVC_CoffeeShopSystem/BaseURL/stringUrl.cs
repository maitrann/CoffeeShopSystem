using System.Configuration;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class stringUrl
    {
        public static string BaseURL = (ConfigurationManager.AppSettings["ApiBaseUrl"] ?? "http://localhost:63566/").TrimEnd('/') + "/";

        public static string Build(string path)
        {
            return BaseURL + path.TrimStart('/');
        }
    }
}
