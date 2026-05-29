using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Security.Policy;
using GoogleAuthentication.Services;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAPI_CoffeeShop.Models;
using WebAPI_CoffeeShop.Utilities;
using System.Configuration;

namespace WebAPI_CoffeeShop.Repositories
{
    public class GoogleAccountRepository
    {
        static string clientId = ConfigurationManager.AppSettings["GoogleClientId"];
        static string url = ConfigurationManager.AppSettings["GoogleRedirectUrl"];
        static string clientSecret = ConfigurationManager.AppSettings["GoogleClientSecret"];

        public static string connectGoogleAuth()
        {
            var response = GoogleAuth.GetAuthUrl(clientId, url);
            return response;
        }
        public async static Task<GoogleAccount> GoogleLoginCallBack(string code)
        {
            var token = await GoogleAuth.GetAuthAccessToken(code, clientId, clientSecret, url);
            var userProfile = await GoogleAuth.GetProfileResponseAsync(token.AccessToken.ToString());
            var user = JsonConvert.DeserializeObject<GoogleAccount>(userProfile);
            user.name = ConvertToUnSign.convert(user.name);
            return user;
        }
    }
}
