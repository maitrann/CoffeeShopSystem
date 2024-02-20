using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Models
{
    public class ObjectInvoice
    {
        public ObjectInvoice()
        {
            this.modelInvoice=new Invoice();
            this.modelInvoiceDetail = new List<InvoiceDetail>();
            this.modelInvoiceSupplier = new List<InvoiceSupplier>();
            this.modelInvoiceAdmin = new InvoiceAdmin();

        }
        public Invoice modelInvoice { get; set; }
        public List<InvoiceDetail> modelInvoiceDetail { get; set; }
        public List<InvoiceSupplier> modelInvoiceSupplier { get; set; }
        public InvoiceAdmin modelInvoiceAdmin { get; set; }
    }
}