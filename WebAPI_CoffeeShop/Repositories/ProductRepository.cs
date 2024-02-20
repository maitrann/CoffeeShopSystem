using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductView> GetProducts()
        {
            List<ProductView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Products
                    .Select(p => new ProductView()
                    {
                        id = p.id,
                        title = p.title,
                        image = p.image,
                        image1 = p.image1,
                        image2 = p.image2,
                        image3 = p.image3,
                        description = p.description,
                        price = p.price,
                        isActive = p.isActive,
                        idcate = p.idcate,
                        titleCate = p.Category.title,
                        idSupplier = p.idSupplier,
                        titleSupplier = p.Supplier.title,
                        discount = p.Discounts.Count(d => d.idProduct == p.id && d.isStatus == 1) > 0 ? p.Discounts.Select(d => d.discount1).FirstOrDefault() : 0,
                        finalPrice = p.Discounts.Count(d => d.idProduct == p.id && d.isStatus == 1) > 0 ? p.price - p.Discounts.Select(d => d.discount1).FirstOrDefault() : p.price,
                    }).OrderByDescending(p => p.id).ToList();
            }
            return query;
        }
        public ProductView GetDetailsProduct(int idProd)
        {
            ProductView query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Products.Where(p => p.id.Equals(idProd))
                    .Select(p => new ProductView()
                    {
                        id = p.id,
                        title = p.title,
                        image = p.image,
                        image1 = p.image1,
                        image2 = p.image2,
                        image3 = p.image3,
                        description = p.description,
                        price = p.price,
                        isActive = p.isActive,
                        idcate = p.idcate,
                        titleCate = p.Category.title,
                        idSupplier = p.idSupplier,
                        titleSupplier = p.Supplier.title,
                        discount = p.Discounts.Count(d => d.idProduct == p.id && d.isStatus == 1) > 0 ? p.Discounts.Select(d => d.discount1).FirstOrDefault() : 0,
                        finalPrice = p.Discounts.Count(d => d.idProduct == p.id && d.isStatus == 1) > 0 ? p.price - p.Discounts.Select(d => d.discount1).FirstOrDefault() : p.price,
                    }).FirstOrDefault();
            }
            return query;
        }

        public List<ProductView> SearchProductsByName(string nameProduct)
        {
            List<ProductView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Products.Where(p=>p.title.Contains(nameProduct))
                    .Select(p => new ProductView()
                    {
                        id = p.id,
                        title = p.title,
                        image = p.image,
                        image1 = p.image1,
                        image2 = p.image2,
                        image3 = p.image3,
                        description = p.description,
                        price = p.price,
                        isActive = p.isActive,
                        idcate = p.idcate,
                        titleCate = p.Category.title,
                        idSupplier = p.idSupplier,
                        titleSupplier = p.Supplier.title,
                        discount = p.Discounts.Count(d => d.idProduct == p.id && d.isStatus == 1) > 0 ? p.Discounts.Select(d => d.discount1).FirstOrDefault() : 0,
                        finalPrice = p.Discounts.Count(d => d.idProduct == p.id && d.isStatus == 1) > 0 ? p.price - p.Discounts.Select(d => d.discount1).FirstOrDefault() : p.price,
                    }).OrderByDescending(p => p.id).ToList();
            }
            return query;
        }

        public List<ProductView> SearchProductsByCategory(int idCategory)
        {
            throw new NotImplementedException();
        }

        public List<ProductView> SearchProductsByPrice(decimal priceStart, decimal priceEnd)
        {
            throw new NotImplementedException();
        }
    }
}