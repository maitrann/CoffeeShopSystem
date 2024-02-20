using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Repositories;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Controllers
{
    public class VoucherAPIController : ApiController
    {
        private IVoucherRepository _voucherRepository = new VoucherRepository();
        [HttpGet]
        public Voucher CartAutoOneVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            return _voucherRepository.CartAutoOneVoucherToSelect(userCreate, priceCartSupp);
        }
        [HttpGet]
        public List<Voucher> CartGetVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            return _voucherRepository.CartGetVoucherToSelect(userCreate, priceCartSupp);
        }
        [HttpGet]
        public Voucher CartIntroVoucherToSelect(int userCreate, decimal? priceCartSupp)
        {
            return _voucherRepository.CartIntroVoucherToSelect(userCreate, priceCartSupp);
        }
        [HttpGet]
        public List<Voucher> GetVoucherByMulIdVoucher(string idVoucher)
        {
            return _voucherRepository.GetVoucherByMulIdVoucher(idVoucher);
        }
    }
}
