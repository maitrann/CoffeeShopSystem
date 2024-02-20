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
        List<ProductView> SearchProductsByName(string nameProduct);
        List<ProductView> SearchProductsByCategory(int idCategory);
        List<ProductView> SearchProductsByPrice(decimal priceStart, decimal priceEnd);

    }
}
