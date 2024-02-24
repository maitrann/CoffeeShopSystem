using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Repositories;

namespace WebAPI_CoffeeShop.Controllers
{
    public class ProductAPIController : ApiController
    {
        private IProductRepository _productRepository = new ProductRepository();

        [HttpGet]
        public List<ProductView> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        [HttpGet]
        public ProductView GetDetailsProduct(int idProd)
        {
            return _productRepository.GetDetailsProduct(idProd);
        }
        [HttpGet]
        public List<ProductView> SearchProductsByKeyWord(string keyword)
        {
            return _productRepository.SearchProductsByKeyWord(keyword);
        }
        [HttpGet]
        public List<ProductView> SearchProductsByCategory(string lsIdCategory)
        {
            return _productRepository.SearchProductsByCategory(lsIdCategory);
        }
        [HttpGet]
        public List<ProductView> SearchProductsByPrice(int typePrice)
        {
            return _productRepository.SearchProductsByPrice(typePrice);
        }
    }
}
