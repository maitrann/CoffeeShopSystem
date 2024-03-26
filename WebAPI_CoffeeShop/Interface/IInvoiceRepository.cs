using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Models;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Interface
{
    internal interface IInvoiceRepository
    {
        List<InvoiceView> GetAllInvoice(int idAccount);
        InvoiceView GetInvoiceDetails(int idAccount, int idInvoice);
        void InsertInvoice(ObjectInvoice objectInvoice);

        
    }
}
