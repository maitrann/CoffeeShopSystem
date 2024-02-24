using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.CallRESTful;
namespace WebMVC_CoffeeShopSystem.Dao
{
    public class AccountDao
    {
        private AccountDao() { }
        private static readonly AccountDao obj = new AccountDao();
        private static AccountDao instance = null;
        public static AccountDao Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new AccountDao();
                        }
                    }
                }
                return instance;
            }
        }
        public bool CheckAccountExistUsername(string username)
        {
            return AccountCall.Instance.CheckAccountExistUsername(username);
        }
        public bool CheckAccountExistEmail(string email)
        {
            return AccountCall.Instance.CheckAccountExistEmail(email);
        }
        public bool CheckAccountExistPhone(string phone)
        {
            return AccountCall.Instance.CheckAccountExistPhone(phone);
        }
        public AccountView SignUpAccount(Account model)
        {
            return AccountCall.Instance.SignUpAccount(model);
        }
        public AccountView SignInAccount(string email, string password)
        {
            return AccountCall.Instance.SignInAccount(email, password);
        }
    }
}