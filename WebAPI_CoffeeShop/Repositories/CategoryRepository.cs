using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<CategoryView> GetMenuCategory()
        {
            List<CategoryView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Categories.Where(c => c.isActive == true).Select(c => new CategoryView()
                {
                    id = c.id,
                    title = c.title,
                    createDate = c.createDate,
                    amountProductOfCate = context.Products.Where(p => p.idcate == c.id & p.isActive == 1).Count()
                }).ToList();
            }
            return query;
        }
    }
}