using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Models.ModelView;
using WebMVC_CoffeeShopSystem.CallRESTful;

namespace WebMVC_CoffeeShopSystem.Dao
{
    public class CategoryDao
    {
        private CategoryDao() { }
        private static readonly CategoryDao obj = new CategoryDao();
        private static CategoryDao instance = null;
        public static CategoryDao Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new CategoryDao();
                        }
                    }
                }
                return instance;
            }
        }
        public List<CategoryView> GetMenuCategory()
        {
            return CategoryCall.Instance.GetMenuCategory();
        }
    }
}