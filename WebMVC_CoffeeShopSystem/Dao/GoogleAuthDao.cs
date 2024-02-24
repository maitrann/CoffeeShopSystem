using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebAPI_CoffeeShop.Models;
using WebMVC_CoffeeShopSystem.CallRESTful;

namespace WebMVC_CoffeeShopSystem.Dao
{
    public class GoogleAuthDao
    {
        private GoogleAuthDao() { }
        private static readonly GoogleAuthDao obj = new GoogleAuthDao();
        private static GoogleAuthDao instance = null;
        public static GoogleAuthDao Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new GoogleAuthDao();
                        }
                    }
                }
                return instance;
            }
        }
        public string connectGoogleAuth()
        {
            return GoogleAuthCall.Instance.connectGoogleAuth();
        }
        public async Task<GoogleAccount> GoogleLoginCallBack(string code)
        {
            return await GoogleAuthCall.Instance.GoogleLoginCallBack(code);
        }
    }
}