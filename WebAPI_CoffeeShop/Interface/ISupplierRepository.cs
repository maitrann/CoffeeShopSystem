using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Interface
{
	internal interface ISupplierRepository
	{
        Supplier RegiterSupplier(Supplier model);
		bool checkExistEmail(string emailRegis);
		bool checkExistPhone(string phoneRegis);
		bool checkPasswordWithEmail(string email, string password);
        SupplierView getSupplierLog(string email, string password);
    }
}
