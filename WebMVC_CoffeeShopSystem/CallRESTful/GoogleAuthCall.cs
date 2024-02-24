using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebAPI_CoffeeShop.Models;
using WebMVC_CoffeeShopSystem.BaseURL;

namespace WebMVC_CoffeeShopSystem.CallRESTful
{
    public class GoogleAuthCall
    {
        GoogleAuthCall() { }
        private static GoogleAuthCall instance = null;
        public static GoogleAuthCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GoogleAuthCall();
                }
                return instance;
            }
        }
        public string connectGoogleAuth()
        {
            string prodInfo = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(googleAuthUrl.connectGoogleAuth).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<string>(prodResponse);
                }
                return prodInfo;
            }
        }
        public async Task<GoogleAccount> GoogleLoginCallBack(string code)
        {
            GoogleAccount prodInfo = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(googleAuthUrl.GoogleLoginCallBack+"?code="+code).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<GoogleAccount>(prodResponse);
                }
                return prodInfo;
            }
        }
    }
}