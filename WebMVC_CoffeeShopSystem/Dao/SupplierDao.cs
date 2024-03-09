using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Repositories;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.CallRESTful;

namespace WebMVC_CoffeeShopSystem.Dao
{
    public class SupplierDao
    {
        private SupplierDao() { }
        private static readonly SupplierDao obj = new SupplierDao();
        private static SupplierDao instance = null;
        public static SupplierDao Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new SupplierDao();
                        }
                    }
                }
                return instance;
            }
        }
        public Supplier RegiterSupplier(Supplier model)
        {
            return SupplierCall.Instance.RegiterSupplier(model);
        }
        public bool checkExistEmail(string emailRegis)
        {
            return SupplierCall.Instance.checkExistEmail(emailRegis);
        }
        public bool checkExistPhone(string phoneRegis)
        {
            return SupplierCall.Instance.checkExistPhone(phoneRegis);
        }
        public bool checkPasswordWithEmail(string email, string password)
        {
            return SupplierCall.Instance.checkPasswordWithEmail(email, password);
        }
        public SupplierView getSupplierLog(string email, string password)
        {
            return SupplierCall.Instance.getSupplierLog(email, password);
        }
    }
}