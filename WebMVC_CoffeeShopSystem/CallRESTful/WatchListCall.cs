using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using WebAPI_CoffeeShop.Models.ModelView;
using WebMVC_CoffeeShopSystem.BaseURL;
using WebAPI_CoffeeShop.Utilities;

namespace WebMVC_CoffeeShopSystem.CallRESTful
{
    public class WatchListCall
    {
        WatchListCall() { }
        private static WatchListCall instance = null;
        public static WatchListCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WatchListCall();
                }
                return instance;
            }
        }
        public List<WatchListView> GetWatchList(int idAccount)
        {
            List<WatchListView> prodInfo = new List<WatchListView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(watchListUrl.GetWatchList + "?idAccount=" + idAccount).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<WatchListView>>(prodResponse);
                }
                return prodInfo;
            }
        }
        public bool InsertWatchList(WatchList model)
        {
            bool flag = new bool();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.PostAsJsonAsync(watchListUrl.InsertWatchList, model).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    flag = JsonConvert.DeserializeObject<bool>(prodResponse);
                }
                return flag;
            }
        }
        public void RemoveWatchList(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(watchListUrl.RemoveWatchList + "?id=" + id).GetAwaiter().GetResult();
            }
        }
    }
}