using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private IVoucherRepository _voucherRepository = new VoucherRepository();
        private List<InvoiceView> GetAllInvoiceInfor(int idAccount)
        {
            List<InvoiceView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Invoices.Where(i => i.idAccount == idAccount)
                    .Select(i => new InvoiceView()
                    {
                        id = i.id,
                        idAccount = i.idAccount,
                        address = i.address,
                        totalPrice = i.totalPrice,
                        idPayment = i.idPayment,
                        idVoucherS = i.idVoucherS,
                        idVoucherA = i.idVoucherA,
                        feeService = i.InvoiceAdmins.Where(invA => invA.idInvoice == i.id).Select(invA => invA.feeService).FirstOrDefault(),
                        createDate = i.createDate,
                        isStatus = i.isStatus,
                        codeInvoice = i.codeInvoice,
                    }).OrderByDescending(i => i.createDate).ToList();
            }
            return query;
        }
        private List<InvoiceDetailsView> GetDetailInvoice(int idInvoice)
        {
            List<InvoiceDetailsView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.InvoiceDetails.Where(invD => invD.idInvoice == idInvoice)
                    .Select(invD => new InvoiceDetailsView()
                    {
                        idSupplier = invD.Cart.Product.idSupplier,
                        titleSupplier = invD.Cart.Product.Supplier.title,
                        isStatusInvDetail = invD.isStatus,
                        dateSuppC = invD.dateSuppC
                    }).Distinct().ToList();
            }
            return query;
        }
        private List<InvoiceDetailsView> GetProductOfDetailInvoice(int idInvoice, int? idSupplier)
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
        public List<InvoiceView> GetAllInvoice(int idAccount)
        {
            List<InvoiceView> query = new List<InvoiceView>();
            List<InvoiceView> getAllInvoiceInfor = GetAllInvoiceInfor(idAccount);
            foreach (var invoice in getAllInvoiceInfor)
            {
                InvoiceView item = new InvoiceView();
                item.id = invoice.id;
                item.idAccount = invoice.idAccount;
                item.address = invoice.address;
                item.totalPrice = invoice.totalPrice;
                item.idPayment = invoice.idPayment;
                item.idVoucherS = invoice.idVoucherS;
                item.idVoucherA = invoice.idVoucherA;
                item.feeService = invoice.feeService;
                item.createDate = invoice.createDate;
                item.isStatus = invoice.isStatus;
                item.codeInvoice = invoice.codeInvoice;
                List<InvoiceDetailsView> getDetailInvoice = new List<InvoiceDetailsView>();
                List<InvoiceDetailsView> getDetailInvoiceTemp = GetDetailInvoice(invoice.id);
                foreach (var detail in getDetailInvoiceTemp)
                {
                    InvoiceDetailsView itemDetail = new InvoiceDetailsView();
                    itemDetail.idSupplier = detail.idSupplier;
                    itemDetail.titleSupplier = detail.titleSupplier;
                    itemDetail.isStatusInvDetail = detail.isStatusInvDetail;
                    itemDetail.dateSuppC = detail.dateSuppC;
                    List<InvoiceDetailsView> getProductOfDetailInvoice = GetProductOfDetailInvoice(invoice.id, detail.idSupplier);
                    itemDetail.lstProdPurchaseOfInvoiceDetails = getProductOfDetailInvoice;
                    getDetailInvoice.Add(itemDetail);
                }
                item.lstInvoiceDetails = getDetailInvoice;
                query.Add(item);
            }
            return query;
        }

        public InvoiceView GetInvoiceDetails(int idAccount, int idInvoice)
        {
            InvoiceView query = new InvoiceView();
            InvoiceView getInvoiceInfor = GetAllInvoiceInfor(idAccount).Where(x => x.id == idInvoice).FirstOrDefault();

            InvoiceView item = new InvoiceView();
            item.id = getInvoiceInfor.id;
            item.idAccount = getInvoiceInfor.idAccount;
            item.address = getInvoiceInfor.address;
            item.totalPrice = getInvoiceInfor.totalPrice;
            item.idPayment = getInvoiceInfor.idPayment;
            item.idVoucherS = getInvoiceInfor.idVoucherS;
            item.discountVoucherS = _voucherRepository.GetVoucherByMulIdVoucher(getInvoiceInfor.idVoucherS).Select(v => v.discount).FirstOrDefault();
            item.idVoucherA = getInvoiceInfor.idVoucherA;
            item.discountVoucherA = _voucherRepository.GetVoucherByMulIdVoucher(getInvoiceInfor.idVoucherA).Select(v => v.discount).Sum();
            item.feeService = getInvoiceInfor.feeService;
            item.createDate = getInvoiceInfor.createDate;
            item.isStatus = getInvoiceInfor.isStatus;
            item.codeInvoice = getInvoiceInfor.codeInvoice;
            List<InvoiceDetailsView> getDetailInvoice = new List<InvoiceDetailsView>();
            List<InvoiceDetailsView> getDetailInvoiceTemp = GetDetailInvoice(getInvoiceInfor.id);
            foreach (var detail in getDetailInvoiceTemp)
            {
                InvoiceDetailsView itemDetail = new InvoiceDetailsView();
                itemDetail.idSupplier = detail.idSupplier;
                itemDetail.titleSupplier = detail.titleSupplier;
                itemDetail.isStatusInvDetail = detail.isStatusInvDetail;
                itemDetail.dateSuppC = detail.dateSuppC;
                List<InvoiceDetailsView> getProductOfDetailInvoice = GetProductOfDetailInvoice(getInvoiceInfor.id, detail.idSupplier);
                itemDetail.lstProdPurchaseOfInvoiceDetails = getProductOfDetailInvoice;
                getDetailInvoice.Add(itemDetail);
            }
            item.lstInvoiceDetails = getDetailInvoice;

            return item;
        }

        private void InsertNewInvoice(Invoice modelInvoice)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                context.Invoices.Add(modelInvoice);
                context.SaveChanges();
            }
        }
        private void InsertNewInvoiceDetail(List<InvoiceDetail> modelInvoiceDetail)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                int idInvoiceNew = context.Invoices.Select(inv => inv.id).OrderByDescending(inv=>inv).FirstOrDefault();
                foreach (var item in modelInvoiceDetail)
                {
                    item.idInvoice = idInvoiceNew;
                    context.InvoiceDetails.Add(item);
                    context.SaveChanges();
                }

            }
        }
        private void InsertNewInvoiceSupplier(List<InvoiceSupplier> modelInvoiceSupplier)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var idInvoiceNew = context.Invoices.Select(inv => inv.id).OrderByDescending(inv => inv).FirstOrDefault();
                foreach (var item in modelInvoiceSupplier)
                {
                    item.idInvoice = idInvoiceNew;
                    context.InvoiceSuppliers.Add(item);
                    context.SaveChanges();
                }
            }
        }
        private void InsertNewInvoiceAdmin(InvoiceAdmin modelInvoiceAdmin)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var idInvoiceNew = context.Invoices.Select(inv => inv.id).OrderByDescending(inv => inv).FirstOrDefault();
                modelInvoiceAdmin.idInvoice = idInvoiceNew;
                context.InvoiceAdmins.Add(modelInvoiceAdmin);
                context.SaveChanges();
            }
        }
        public void InsertInvoice(ObjectInvoice objectInvoice)
        {
            InsertNewInvoice(objectInvoice.modelInvoice);
            InsertNewInvoiceDetail(objectInvoice.modelInvoiceDetail);
            InsertNewInvoiceSupplier(objectInvoice.modelInvoiceSupplier);
            InsertNewInvoiceAdmin(objectInvoice.modelInvoiceAdmin);
        }


    }
}