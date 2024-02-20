using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class InvoiceDetailsView
    {
        public int idInvoiceDetail { get; set; }
        public Nullable<int> idInvoice { get; set; }
        public Nullable<int> idCart { get; set; }
        public int? idSupplier { get; set; }
        public string titleSupplier { get; set; }
        public Nullable<int> idProduct { get; set; }
        public string titleProd { get; set; }
        public string imageProd { get; set; }
        public Nullable<int> Amount { get; set; }
        public decimal? UnitPrice { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> isStatusInvDetail { get; set; }
        public Nullable<System.DateTime> dateSuppC { get; set; }
        public List<InvoiceDetailsView> lstProdPurchaseOfInvoiceDetails { get; set; }

    }
}