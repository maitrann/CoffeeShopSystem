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
using WebAPI_CoffeeShop.Models;

namespace WebMVC_CoffeeShopSystem.CallRESTful
{
    public class InvoiceCall
    {
        InvoiceCall() { }
        private static InvoiceCall instance = null;
        public static InvoiceCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InvoiceCall();
                }
                return instance;
            }
        }
        public List<InvoiceView> GetAllInvoice(int idAccount)
        {
            List<InvoiceView> prodInfo = new List<InvoiceView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(invoiceUrl.GetAllInvoice + "?idAccount=" + idAccount).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<InvoiceView>>(prodResponse);
                }
                return prodInfo;
            }
        }
        public InvoiceView GetInvoiceDetails(int idAccount, int idInvoice)
        {
            InvoiceView prodInfo = new InvoiceView();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(invoiceUrl.GetInvoiceDetails + "?idAccount=" + idAccount+"&idInvoice="+idInvoice).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<InvoiceView>(prodResponse);
                }
                return prodInfo;
            }
        }
        public void InsertInvoice(ObjectInvoice model)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.PostAsJsonAsync(invoiceUrl.InsertInvoice, model).GetAwaiter().GetResult();
            }
        }
        public List<InvoiceSupplierView> GetInvoiceOfSupplier(int idSupplier)
        {
            List<InvoiceSupplierView> prodInfo = new List<InvoiceSupplierView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(invoiceUrl.GetInvoiceOfSupplier + "?idSupplier=" + idSupplier).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<InvoiceSupplierView>>(prodResponse);
                }
                return prodInfo;
            }
        }
    }
}