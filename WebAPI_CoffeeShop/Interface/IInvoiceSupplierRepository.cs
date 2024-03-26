using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Models.ModelView;

namespace WebAPI_CoffeeShop.Interface
{
    internal interface IInvoiceSupplierRepository
    {
        List<InvoiceSupplierView> GetInvoiceOfSupplier(int idSupplier);
    }
}
