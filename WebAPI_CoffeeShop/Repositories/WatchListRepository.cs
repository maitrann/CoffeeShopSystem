using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class WatchListRepository : IWatchListRepository
    {
        public List<WatchListView> GetWatchList(int idAccount)
        {
            List<WatchListView> query;

            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.WatchLists.Where(w => w.idAccount == idAccount).Select(w => new WatchListView()
                {
                    id = w.id,
                    idProduct = w.idProduct,
                    titleProduct = w.Product.title,
                    image = w.Product.image,
                    image1 = w.Product.image1,
                    idCate = w.Product.idcate,
                    titleCate = w.Product.Category.title,
                    price = w.Product.price,
                    priceCurr = w.Product.Discounts.Count(d => d.idProduct == w.Product.id && d.isStatus == 1) > 0 ? w.Product.price - w.Product.Discounts.Select(d => d.discount1).FirstOrDefault() : w.Product.price,
                    createDate = w.createDate,
                }).OrderByDescending(w => w.createDate).ToList();
            }
            return query;
        }

        public bool InsertWatchList(WatchList model)
        {
            bool flag = true;
            using (var context = new CoffeeShopSystemEntities())
            {
                var check = context.WatchLists.Where(w => w.idAccount == model.idAccount & w.idProduct == model.idProduct).FirstOrDefault();
                if (check != null)
                {
                    flag = false;
                    context.WatchLists.Remove(check);
                    context.SaveChanges();
                }
                else
                {
                    context.WatchLists.Add(model);
                    context.SaveChanges();
                }
            }
            return flag;
        }
        public void RemoveWatchList(int id)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var model = context.WatchLists.Where(w=>w.id==id).FirstOrDefault();
                context.WatchLists.Remove(model);
                context.SaveChanges();
            }
        }
    }
}