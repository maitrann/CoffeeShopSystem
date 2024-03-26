using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Models;
using WebAPI_CoffeeShop.Models.ModelView;
using WebMVC_CoffeeShopSystem.CallRESTful;

namespace WebMVC_CoffeeShopSystem.Dao
{
    public class InvoiceDao
    {
        private InvoiceDao() { }
        private static readonly InvoiceDao obj = new InvoiceDao();
        private static InvoiceDao instance = null;
        public static InvoiceDao Instance
        {
            get
            {
                if (instance == null) // Thread Safety Singleton using Double-Check Locking
                {
                    lock (obj) // Thread Safety Singleton
                    {
                        if (instance == null)
                        {
                            instance = new InvoiceDao();
                        }
                    }
                }
                return instance;
            }
        }
        public List<InvoiceView> GetAllInvoice(int idAccount)
        {
            return InvoiceCall.Instance.GetAllInvoice(idAccount);
        }
        public InvoiceView GetInvoiceDetails(int idAccount, int idInvoice)
        {
            return InvoiceCall.Instance.GetInvoiceDetails(idAccount,idInvoice);
        }
        public void InsertInvoice(ObjectInvoice model)
        {
            InvoiceCall.Instance.InsertInvoice(model);
        }
        public List<InvoiceSupplierView> GetInvoiceOfSupplier(int idSupplier)
        {
            return InvoiceCall.Instance.GetInvoiceOfSupplier(idSupplier);
        }
    }
}