namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class watchListUrl
    {
        public static string GetWatchList = stringUrl.Build("api/WatchListAPI/GetWatchList");
        public static string InsertWatchList = stringUrl.Build("api/WatchListAPI/InsertWatchList");
        public static string RemoveWatchList = stringUrl.Build("api/WatchListAPI/RemoveWatchList");
    }
}
