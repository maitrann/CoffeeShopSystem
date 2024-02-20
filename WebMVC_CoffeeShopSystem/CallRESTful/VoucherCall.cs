using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.BaseURL;

namespace WebMVC_CoffeeShopSystem.CallRESTful
{
    public class VoucherCall
    {
        VoucherCall() { }
        private static VoucherCall instance = null;
        public static VoucherCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VoucherCall();
                }
                return instance;
            }
        }
        public Voucher CartAutoOneVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            Voucher prodInfo = new Voucher();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.GetAsync(voucherUrl.CartAutoOneVoucherToSelect + "?userCreate=" + userCreate+ "&priceCartSupp="+priceCartSupp).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<Voucher>(prodResponse);
                }
                return prodInfo;
            }
        }
        public List<Voucher> CartGetVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            List<Voucher> prodInfo = new List<Voucher>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.GetAsync(voucherUrl.CartGetVoucherToSelect + "?userCreate=" + userCreate + "&priceCartSupp=" + priceCartSupp).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<Voucher>>(prodResponse);
                }
                return prodInfo;
            }
        }

        public Voucher CartIntroVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            Voucher prodInfo = new Voucher();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.GetAsync(voucherUrl.CartIntroVoucherToSelect + "?userCreate=" + userCreate + "&priceCartSupp=" + priceCartSupp).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<Voucher>(prodResponse);
                }
                return prodInfo;
            }
        }
        public List<Voucher> GetVoucherByMulIdVoucher(string idVoucher)
        {
            List<Voucher> prodInfo = new List<Voucher>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.GetAsync(voucherUrl.GetVoucherByMulIdVoucher + "?idVoucher=" + idVoucher).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<Voucher>>(prodResponse);
                }
                return prodInfo;
            }
        }
    }
}