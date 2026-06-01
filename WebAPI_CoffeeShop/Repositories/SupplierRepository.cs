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
            string generatedPassword = RandomString.randomString(12);
            model.avatar = "BLANK";
            model.image = "No Image";
            model.title = ConvertToUnSign.convert(model.title);
            model.address = ConvertToUnSign.convert(model.address);
            model.username = "BLANK";
            model.password = PasswordHasher.HashPassword(generatedPassword);
            model.requestDate = DateTime.Now;
            model.createDate = DateTime.Now;
            model.isActive = 1;
            model.saltKey = "BLANK";
            using (var context = new CoffeeShopSystemEntities())
            {
                context.Suppliers.Add(model);
                context.SaveChanges();
            }
            model.password = generatedPassword;
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
                var supplier = context.Suppliers.FirstOrDefault(s => s.email == email);
                if (supplier != null && PasswordHasher.VerifyPassword(password, supplier.password))
                {
                    if (!PasswordHasher.IsHashed(supplier.password))
                    {
                        supplier.password = PasswordHasher.HashPassword(password);
                        context.SaveChanges();
                    }
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
                var supplierEntity = context.Suppliers.FirstOrDefault(s => s.email == email & s.isActive == 1);
                if (supplierEntity == null || !PasswordHasher.VerifyPassword(password, supplierEntity.password))
                {
                    return null;
                }

                if (!PasswordHasher.IsHashed(supplierEntity.password))
                {
                    supplierEntity.password = PasswordHasher.HashPassword(password);
                    context.SaveChanges();
                }

                supplier = new SupplierView()
                    {
                        id = supplierEntity.id,
                        avatar = supplierEntity.avatar,
                        image = supplierEntity.image,
                        title = supplierEntity.title,
                        phone = supplierEntity.phone,
                        email = supplierEntity.email,
                        address = supplierEntity.address,
                        username = supplierEntity.username,
                        password = string.Empty,
                        createDate = supplierEntity.createDate,
                        isActive = supplierEntity.isActive,
                    };
            }
            return supplier;
        }
        public SupplierView GetSupplierById(int idSupplier)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                return context.Suppliers.Where(s => s.id == idSupplier && s.isActive == 1)
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
                        password = string.Empty,
                        createDate = s.createDate,
                        isActive = s.isActive,
                        productCount = s.Products.Count(p => p.isActive == 1)
                    }).FirstOrDefault();
            }
        }
    }
}
