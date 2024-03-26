using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Repositories;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Controllers
{
    public class InvoiceAPIController : ApiController
    {
        private IInvoiceRepository _invoiceRepository = new InvoiceRepository();
        private IInvoiceSupplierRepository _invoiceSupplierRepository= new InvoiceSupplierRepository();
        [HttpGet]
        public List<InvoiceView> GetAllInvoice(int idAccount)
        {
            return _invoiceRepository.GetAllInvoice(idAccount);
        }
        [HttpGet]
        public InvoiceView GetInvoiceDetails(int idAccount, int idInvoice)
        {
            return _invoiceRepository.GetInvoiceDetails(idAccount,idInvoice);
        }
        [HttpPost]
        public void InsertInvoice([FromBody]ObjectInvoice objectInvoice)
        {
            _invoiceRepository.InsertInvoice(objectInvoice);
        }

        [HttpGet]
        public List<InvoiceSupplierView> GetInvoiceOfSupplier(int idSupplier)
        {
            return _invoiceSupplierRepository.GetInvoiceOfSupplier(idSupplier);
        }
    }
}
