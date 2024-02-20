using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        public List<Voucher> CartGetVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            List<Voucher> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                List<Voucher> tempQuery;
                List<Voucher> canApply = new List<Voucher>();
                List<Voucher> noCanApply = new List<Voucher>();
                tempQuery = context.Vouchers.Where(v => v.isActive == 1 & v.usercreate == userCreate.ToString())
                    .OrderByDescending(v => v.discount).ToList();
                foreach (var item in tempQuery)
                {
                    Voucher itemCanApply = new Voucher();
                    Voucher itemNoCanApply = new Voucher();
                    if (priceCartSupp >= item.condition)
                    {
                        itemCanApply.id = item.id;
                        itemCanApply.condition = item.condition;
                        itemCanApply.discount = item.discount;
                        itemCanApply.usercreate = item.usercreate;
                        itemCanApply.startDate = item.startDate;
                        itemCanApply.endDate = item.endDate;
                        itemCanApply.isActive = item.isActive;
                        itemCanApply.used = item.used;
                        itemCanApply.idenVou = item.idenVou;
                        canApply.Add(itemCanApply);
                    }
                    else
                    {
                        itemNoCanApply.id = item.id;
                        itemNoCanApply.condition = item.condition;
                        itemNoCanApply.discount = item.discount;
                        itemNoCanApply.usercreate = item.usercreate;
                        itemNoCanApply.startDate = item.startDate;
                        itemNoCanApply.endDate = item.endDate;
                        itemNoCanApply.isActive = item.isActive;
                        itemNoCanApply.used = item.used;
                        itemNoCanApply.idenVou = item.idenVou;
                        noCanApply.Add(itemNoCanApply);
                    }
                }
                query = new List<Voucher>(canApply.Count() + noCanApply.Count());
                query.AddRange(canApply);
                query.AddRange(noCanApply);
            }
            return query;
        }
        public Voucher CartAutoOneVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            Voucher query;
            using (var context = new CoffeeShopSystemEntities())
            {
                var maxDiscount = context.Vouchers.Where(temp => temp.isActive == 1 & temp.usercreate == userCreate.ToString()
                & temp.condition <= priceCartSupp).Max(temp => temp.discount);

                query = context.Vouchers.Where(v => v.isActive == 1 & v.usercreate == userCreate.ToString()
                & v.condition <= priceCartSupp & v.discount == maxDiscount).FirstOrDefault();
            }
            return query;
        }
        public Voucher CartIntroVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            Voucher query;
            using (var context = new CoffeeShopSystemEntities())
            {
                var minDiscount = context.Vouchers.Where(temp => temp.isActive == 1 & temp.usercreate == userCreate.ToString()
                & temp.condition > priceCartSupp).Min(temp => temp.discount);

                query = context.Vouchers.Where(v => v.isActive == 1 & v.usercreate == userCreate.ToString()
                & v.condition > priceCartSupp & v.discount == minDiscount).FirstOrDefault();
            }
            return query;
        }
        public List<Voucher> GetVoucherByMulIdVoucher(string idVoucher)
        {
            List<Voucher> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Vouchers.Where(v => idVoucher.Contains(v.id)).ToList();
            }
            return query;
        }
    }
}