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
    public class ReviewCall
    {
        ReviewCall() { }
        private static ReviewCall instance = null;
        public static ReviewCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReviewCall();
                }
                return instance;
            }
        }

        public List<Review> GetReviewsOfProduct(int? idProduct)
        {
            List<Review> prodInfo = new List<Review>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(reviewUrl.GetReviewsOfProduct + "?idProduct=" + idProduct).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<Review>>(prodResponse);
                }
                return prodInfo;
            }
        }
        public double? avgReviewOfProduct(int? idProduct)
        {
            double? avgReview = 0;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(reviewUrl.avgReviewOfProduct + "?idProduct=" + idProduct).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    avgReview = JsonConvert.DeserializeObject<double?>(prodResponse);
                }
                return avgReview;
            }
        }
        public int countReviewOfProduct(int? idProduct)
        {
            int avgReview = 0;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(reviewUrl.countReviewOfProduct + "?idProduct=" + idProduct).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    avgReview = JsonConvert.DeserializeObject<int>(prodResponse);
                }
                return avgReview;
            }
        }
    }
}