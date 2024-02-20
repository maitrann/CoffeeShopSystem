using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class InvoiceView
    {
        public int id { get; set; }
        public Nullable<int> idAccount { get; set; }
        public string address { get; set; }
        public Nullable<decimal> totalPrice { get; set; }
        public string idPayment { get; set; }
        public string idVoucherS { get; set; }
        public Nullable<int> discountVoucherS { get; set; }
        public string idVoucherA { get; set; }
        public Nullable<int> discountVoucherA { get; set; }
        public Nullable<decimal> feeService { get; set; }

        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> isStatus { get; set; }
        public string codeInvoice { get; set; }
        public Nullable<int> Quantity { get; set; }
        public List<InvoiceDetailsView> lstInvoiceDetails { get; set; }
    }
}