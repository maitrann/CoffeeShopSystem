using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class InvoiceSupplierView
    {
        public int id { get; set; }
        public int? idCustomer { get; set; }
        public string nameCustomer { get; set; }
        public Nullable<int> idSupplier { get; set; }
        public string titleSupplier { get; set; }
        public Nullable<decimal> priceInvSupplierFirst { get; set; }
        public Nullable<decimal> priceSupplier { get; set; }
        public Nullable<decimal> profitForAdmin { get; set; }

        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> idInvoice { get; set; }
        public string codeInvoice { get; set; }
        public Nullable<int> statusInvSupplier { get; set; }
        public Nullable<System.DateTime> dateMaxC { get; set; }
        public List<InvoiceDetailsView> detailsInvoiceSupplier { get; set; }
    }
}