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
using System.Security.Principal;

namespace WebMVC_CoffeeShopSystem.CallRESTful
{
    public class CartCall
    {
        CartCall() { }
        private static CartCall instance = null;
        public static CartCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartCall();
                }
                return instance;
            }
        }
        public List<CartView> getCart(int idAccount)
        {
            List<CartView> prodInfo = new List<CartView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(cartUrl.GetCart + "?idAccount=" + idAccount).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<CartView>>(prodResponse);
                }
                return prodInfo;
            }
        }
        public void UpdateInsertCart(Cart model)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.PostAsJsonAsync(cartUrl.UpdateInsertCart, model).GetAwaiter().GetResult();
            }
        }
        public void UpdateCart(int idCart, int amount, decimal? price)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(cartUrl.UpdateCart + "?idCart=" + idCart
                    + "&amount=" + amount + "&price=" + price).GetAwaiter().GetResult();
            }
        }
        public void DeleteCart(int idCart)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(cartUrl.DeleteCart + "?idCart=" + idCart).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
        }
        public List<CartView> GetCartCheckout(int idAccount, string lsCartCheckout)
        {
            List<CartView> prodInfo = new List<CartView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(cartUrl.GetCartCheckout + "?idAccount=" + idAccount+ "&lsCartCheckout="+lsCartCheckout).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<CartView>>(prodResponse);
                }
                return prodInfo;
            }
        }
        public int quantityCartOfUser(int idAccount)
        {
            int cart = 0;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(cartUrl.quantityCartOfUser + "?idAccount=" + idAccount).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    cart = JsonConvert.DeserializeObject<int>(prodResponse);
                }
                return cart;
            }

        }
        public void UpdateCartCheckout(string lsIdCart)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(cartUrl.UpdateCartCheckout + "?lsIdCart=" + lsIdCart).GetAwaiter().GetResult();
            }
        }
    }
}