using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebMVC_CoffeeShopSystem.CallRESTful;
using WebAPI_CoffeeShop.Models.ModelView;
using System.Web.Razor.Tokenizer.Symbols;

namespace WebMVC_CoffeeShopSystem.Repositories
{
    public class ProductDao
    {
        private ProductDao() { }
        private static readonly ProductDao obj = new ProductDao();
        private static ProductDao instance = null;
        public static ProductDao Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new ProductDao();
                        }
                    }
                }
                return instance;
            }
        }
        public List<ProductView> getProducts()
        {
            return ProductsCall.Instance.getProducts();
        }
        public ProductView GetDetailsProduct(int? idProd)
        {
            return ProductsCall.Instance.GetDetailsProduct(idProd);
        }
        public List<ProductView> SearchProductsByKeyWord(string keyword)
        {
            return ProductsCall.Instance.SearchProductsByKeyWord(keyword);
        }
        public List<ProductView> SearchProductsByCategory(string lsIdCategory)
        {
            return ProductsCall.Instance.SearchProductsByCategory(lsIdCategory);

        }
        public List<ProductView> SearchProductsByPrice(int typePrice)
        {
            return ProductsCall.Instance.SearchProductsByPrice(typePrice);

        }
    }
}