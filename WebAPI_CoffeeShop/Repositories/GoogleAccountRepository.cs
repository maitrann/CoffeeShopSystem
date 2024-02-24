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

namespace WebAPI_CoffeeShop.Repositories
{
    public class GoogleAccountRepository
    {
        static string clientId = "112758736944-noum7ab9b6vkqshmagsnbn85u13houei.apps.googleusercontent.com";
        static string url = "http://localhost:52519/Signin/GoogleLoginCallBack";
        static string clientSecret = "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";
        private static string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
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
            user.name = convertToUnSign(user.name);
            return user;
        }
    }
}