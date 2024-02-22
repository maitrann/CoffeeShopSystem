using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class watchListUrl
    {
        public static string GetWatchList = "http://localhost:63566/api/WatchListAPI/GetWatchList";
        public static string InsertWatchList = "http://localhost:63566/api/WatchListAPI/InsertWatchList";
        public static string RemoveWatchList = "http://localhost:63566/api/WatchListAPI/RemoveWatchList";

    }
}