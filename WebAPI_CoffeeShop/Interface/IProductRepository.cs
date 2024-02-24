using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Models.ModelView;

namespace WebAPI_CoffeeShop.Interface
{
    internal interface IProductRepository
    {
        List<ProductView> GetProducts();
        ProductView GetDetailsProduct(int idProd);
        List<ProductView> SearchProductsByKeyWord(string keyword);
        List<ProductView> SearchProductsByCategory(string lsIdCategory);
        List<ProductView> SearchProductsByPrice(int typePrice);

    }
}
