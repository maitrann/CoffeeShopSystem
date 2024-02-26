using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using WebAPI_CoffeeShop.Models.ModelView;
using WebMVC_CoffeeShopSystem.BaseURL;

namespace WebMVC_CoffeeShopSystem.CallRESTful
{
    public class CategoryCall
    {
        CategoryCall() { }
        private static CategoryCall instance = null;
        public static CategoryCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryCall();
                }
                return instance;
            }
        }
        public List<CategoryView> GetMenuCategory()
        {
            List<CategoryView> prodInfo = new List<CategoryView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(categoryUrl.GetMenuCategory).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<CategoryView>>(prodResponse);
                }
                return prodInfo;
            }
        }
    }
}