using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Repositories;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Controllers
{
    public class SupplierAPIController : ApiController
    {
		ISupplierRepository _supplierRepository = new SupplierRepository();
		[HttpPost]
		public Supplier RegiterSupplier(Supplier model)
		{
			return _supplierRepository.RegiterSupplier(model);
		}
		[HttpGet]
		public bool checkExistEmail(string emailRegis)
		{
			return _supplierRepository.checkExistEmail(emailRegis);
		}
		[HttpGet]
		public bool checkExistPhone(string phoneRegis)
		{
			return _supplierRepository.checkExistPhone(phoneRegis);
		}
        [HttpGet]
        public bool checkPasswordWithEmail(string email, string password)
        {
            return _supplierRepository.checkPasswordWithEmail(email,password);
        }
		[HttpGet]
        public SupplierView getSupplierLog(string email, string password)
		{
			return _supplierRepository.getSupplierLog(email,password);
		}
    }
}
