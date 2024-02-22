using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Interface
{
    internal interface IWatchListRepository
    {
        bool InsertWatchList(WatchList model);
        List<WatchListView> GetWatchList(int idAcccount);
        void RemoveWatchList(int id);

    }
}
