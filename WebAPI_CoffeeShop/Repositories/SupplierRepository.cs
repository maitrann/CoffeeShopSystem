using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public Supplier RegiterSupplier(Supplier model)
        {
            model.avatar = "BLANK";
            model.image = "No Image";
            model.title = ConvertToUnSign.convert(model.title);
            model.address = ConvertToUnSign.convert(model.address);
            model.username = "BLANK";
            model.password = RandomString.randomString(12);
            model.requestDate = DateTime.Now;
            model.createDate = DateTime.Now;
            model.isActive = 1;
            model.saltKey = "BLANK";
            using (var context = new CoffeeShopSystemEntities())
            {
                context.Suppliers.Add(model);
                context.SaveChanges();
            }
            return model;
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
        public bool checkPasswordWithEmail(string email, string password)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var supplier = context.Suppliers.Where(s => s.email == email & s.password == password).FirstOrDefault();
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

        public SupplierView getSupplierLog(string email, string password)
        {
            SupplierView supplier = new SupplierView();
            using (var context = new CoffeeShopSystemEntities())
            {
                supplier = context.Suppliers.Where(s => s.email == email & s.password == password & s.isActive == 1)
                    .Select(s => new SupplierView()
                    {
                        id = s.id,
                        avatar = s.avatar,
                        image = s.image,
                        title = s.title,
                        phone = s.phone,
                        email = s.email,
                        address = s.address,
                        username = s.username,
                        password = s.password,
                        createDate = s.createDate,
                        isActive = s.isActive,
                    }).FirstOrDefault();
            }
            return supplier;
        }
    }
}