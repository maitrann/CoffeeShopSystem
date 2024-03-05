using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public bool RegiterSupplier(Supplier model)
        {
            bool flag = false;
            model.title = ConvertToUnSign.convert(model.title);
            model.address = ConvertToUnSign.convert(model.address);
            using (var context = new CoffeeShopSystemEntities())
            {
                context.Suppliers.Add(model);
                context.SaveChanges();
                flag = true;
            }
            return flag;
        }
        public bool checkExistEmail(string emailRegis)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var supplier = context.Suppliers.Where(s => s.email == emailRegis).FirstOrDefault();
                if (supplier != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool checkExistPhone(string phoneRegis)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var supplier = context.Suppliers.Where(s => s.phone == phoneRegis).FirstOrDefault();
                if (supplier != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}