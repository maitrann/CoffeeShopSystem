using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.CallRESTful;

namespace WebMVC_CoffeeShopSystem.Repositories
{
    public class VoucherDao
    {
        private VoucherDao() { }
        private static readonly VoucherDao obj = new VoucherDao();
        private static VoucherDao instance = null;
        public static VoucherDao Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new VoucherDao();
                        }
                    }
                }
                return instance;
            }
        }
        public Voucher CartAutoOneVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            return VoucherCall.Instance.CartAutoOneVoucherToSelect(userCreate, priceCartSupp);
        }
        public List<Voucher> CartGetVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            return VoucherCall.Instance.CartGetVoucherToSelect(userCreate,priceCartSupp);
        }
        public Voucher CartIntroVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            return VoucherCall.Instance.CartIntroVoucherToSelect(userCreate, priceCartSupp);
        }
        public List<Voucher> GetVoucherByMulIdVoucher(string idVoucher)
        {
            return VoucherCall.Instance.GetVoucherByMulIdVoucher(idVoucher);
        }
    }
}