using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using WebAPI_CoffeeShop.Models.ModelView;
using WebMVC_CoffeeShopSystem.BaseURL;
using System.Web.Helpers;
using PayPal.Api;
using WebAPI_CoffeeShop.Utilities;

namespace WebMVC_CoffeeShopSystem.CallRESTful
{
    public class AccountCall
    {
        AccountCall() { }
        private static AccountCall instance = null;
        public static AccountCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountCall();
                }
                return instance;
            }
        }
        public bool CheckAccountExistUsername(string username)
        {
            bool prodInfo = true;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(accountUrl.CheckAccountExistUsername + "?username=" + username).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<bool>(prodResponse);
                }
                return prodInfo;
            }
        }
        public bool CheckAccountExistEmail(string email)
        {
            bool prodInfo = true;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(accountUrl.CheckAccountExistEmail + "?email=" + email).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<bool>(prodResponse);
                }
                return prodInfo;
            }
        }
        public bool CheckAccountExistPhone(string phone)
        {
            bool prodInfo = true;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(accountUrl.CheckAccountExistPhone + "?phone=" + phone).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<bool>(prodResponse);
                }
                return prodInfo;
            }
        }
        public AccountView SignUpAccount(Account model)
        {
            AccountView prodInfo = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.PostAsJsonAsync(accountUrl.SignUpAccount, model).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<AccountView>(prodResponse);
                }
                return prodInfo;
            }
        }
        public AccountView SignInAccount(string email, string password)
        {
            AccountView prodInfo = new AccountView();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(accountUrl.SignInAccount + "?email=" + email + "&password=" + password).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<AccountView>(prodResponse);
                }
                return prodInfo;
            }
        }
    }
}