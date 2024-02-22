using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.CallRESTful;
using WebMVC_CoffeeShopSystem.Repositories;

namespace WebMVC_CoffeeShopSystem.Dao
{
    public class WatchListDao
    {
        private WatchListDao() { }
        private static readonly WatchListDao obj = new WatchListDao();
        private static WatchListDao instance = null;
        public static WatchListDao Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new WatchListDao();
                        }
                    }
                }
                return instance;
            }
        }
        public List<WatchListView> GetWatchList(int idAccount)
        {
            return WatchListCall.Instance.GetWatchList(idAccount);
        }
        public bool InsertWatchList(WatchList model)
        {
            return WatchListCall.Instance.InsertWatchList(model);
        }
        public void RemoveWatchList(int id)
        {
            WatchListCall.Instance.RemoveWatchList(id);
        }
    }
}