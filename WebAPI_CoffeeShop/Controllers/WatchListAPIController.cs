using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Repositories;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Controllers
{
    public class WatchListAPIController : ApiController
    {
        private IWatchListRepository _watchListRepository = new WatchListRepository();

        [HttpPost]
        public bool InsertWatchList([FromBody] WatchList model)
        {
            return _watchListRepository.InsertWatchList(model);
        }
        [HttpGet]
        public List<WatchListView> GetWatchList(int idAccount)
        {
            return _watchListRepository.GetWatchList(idAccount);
        }
        [HttpGet]
        public void RemoveWatchList(int id)
        {
            _watchListRepository.RemoveWatchList(id);
        }
    }
}
