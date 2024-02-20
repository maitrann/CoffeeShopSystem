using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Interface
{
    internal interface IVoucherRepository
    {
        Voucher CartAutoOneVoucherToSelect(int userCreate, decimal? priceCartSupp);
        List<Voucher> CartGetVoucherToSelect(int userCreate, decimal? priceCartSupp);
        Voucher CartIntroVoucherToSelect(int userCreate, decimal? priceCartSupp);
        List<Voucher> GetVoucherByMulIdVoucher(string idVoucher);
    }
}
