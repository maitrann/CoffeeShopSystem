using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class InvoiceSupplierRepository : IInvoiceSupplierRepository
    {
        private const double V = 0.1;

        private decimal? GetPriceInvSupplierFirst(int? idInvoice, int? idSupplier)
        {
            List<InvoiceSupplierView> query = new List<InvoiceSupplierView>();
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.InvoiceDetails.Where(invS => invS.idInvoice == idInvoice && invS.Cart.Product.idSupplier == idSupplier)
                    .Select(x => new InvoiceSupplierView()
                    {
                        priceInvSupplierFirst = x.Cart.Price
                    }).ToList();
            }
            return query.Sum(q=>q.priceInvSupplierFirst);
        }
        private List<InvoiceSupplierView> GetLstInvoiceOfSupplier(int idSupplier)
        {
            List<InvoiceSupplierView> query;
            decimal tenPercent = (decimal)V;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.InvoiceSuppliers.Where(invS => invS.idSupplier == idSupplier)
                    .Select(invS => new InvoiceSupplierView()
                    {
                        idInvoice = invS.idInvoice,
                        codeInvoice = invS.Invoice.codeInvoice,
                        idCustomer=invS.Invoice.idAccount,
                        nameCustomer=context.InvoiceDetails.Where(invD=>invD.idInvoice==invS.idInvoice).Select(invD=>invD.Cart.Account.name).FirstOrDefault().ToString(),
                        idSupplier = invS.idSupplier,
                        titleSupplier = invS.Supplier.title,
                        statusInvSupplier = invS.status,
                        profitForAdmin = tenPercent * (invS.price),
                        priceSupplier = invS.price,
                        createDate = invS.createDate,
                    }).Distinct().OrderByDescending(i => i.createDate).ToList();
            }
            return query;
        }
        private List<InvoiceDetailsView> GetDetailInvoiceOfSupplier(int? idInvoice, int? idSupplier)
        {
            List<InvoiceDetailsView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.InvoiceDetails.Where(invD => invD.idInvoice == idInvoice && invD.Cart.Product.idSupplier == idSupplier)
                    .Select(invD => new InvoiceDetailsView()
                    {
                        idInvoiceDetail = invD.id,
                        idCart = invD.idCart,
                        idProduct = invD.Cart.idProduct,
                        titleProd = invD.Cart.Product.title,
                        imageProd = invD.Cart.Product.image,
                        UnitPrice = invD.Cart.Price / invD.Cart.Amount,
                        Amount = invD.Cart.Amount,
                        Price = invD.Cart.Price,
                    }).ToList();
            }
            return query;
        }
        public List<InvoiceSupplierView> GetInvoiceOfSupplier(int idSupplier)
        {
            List<InvoiceSupplierView> query = new List<InvoiceSupplierView>();
            var lstInvoice = GetLstInvoiceOfSupplier(idSupplier);
            foreach (var item in lstInvoice)
            {
                InvoiceSupplierView itemInv = new InvoiceSupplierView();
                itemInv.idInvoice = item.idInvoice;
                itemInv.codeInvoice= item.codeInvoice;
                itemInv.idCustomer = item.idCustomer;
                itemInv.nameCustomer= item.nameCustomer;
                itemInv.idSupplier = item.idSupplier;
                itemInv.titleSupplier= item.titleSupplier;
                itemInv.statusInvSupplier= item.statusInvSupplier;
                item.priceInvSupplierFirst = GetPriceInvSupplierFirst(item.idInvoice,item.idSupplier);
                itemInv.profitForAdmin= item.profitForAdmin;
                itemInv.priceSupplier= item.priceSupplier;
                itemInv.createDate = item.createDate;
                itemInv.detailsInvoiceSupplier = GetDetailInvoiceOfSupplier(item.idInvoice, item.idSupplier);
                query.Add(itemInv);
            }
            return query.ToList();
        }
    }
}