using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using WebMVC_CoffeeShopSystem.BaseURL;
using WebAPI_CoffeeShop.Utilities;
using System.Reflection;
using WebAPI_CoffeeShop.Models.ModelView;

namespace WebMVC_CoffeeShopSystem.CallRESTful
{
    public class SupplierCall
    {
        SupplierCall() { }
        private static SupplierCall instance = null;
        public static SupplierCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SupplierCall();
                }
                return instance;
            }
        }
        public Supplier RegiterSupplier(Supplier model)
        {
            Supplier prodInfo = new Supplier();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.PostAsJsonAsync(supplierUrl.RegiterSupplier, model).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<Supplier>(prodResponse);
                }
                return prodInfo;
            }
        }
        public bool checkExistEmail(string emailRegis)
        {
            bool prodInfo = false;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(supplierUrl.checkExistEmail + "?emailRegis=" + emailRegis).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<bool>(prodResponse);
                }
                return prodInfo;
            }
        }
        public bool checkExistPhone(string phoneRegis)
        {
            bool prodInfo = false;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(supplierUrl.checkExistPhone + "?phoneRegis=" + phoneRegis).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<bool>(prodResponse);
                }
                return prodInfo;
            }
        }
        public bool checkPasswordWithEmail(string email, string password)
        {
            bool prodInfo = false;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(supplierUrl.checkPasswordWithEmail + "?email=" + email + "&password=" + password).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<bool>(prodResponse);
                }
                return prodInfo;
            }
        }
        public SupplierView getSupplierLog(string email, string password)
        {
            SupplierView prodInfo = new SupplierView();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(supplierUrl.getSupplierLog + "?email=" + email + "&password=" + password).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<SupplierView>(prodResponse);
                }
                return prodInfo;
            }
        }
    }
}