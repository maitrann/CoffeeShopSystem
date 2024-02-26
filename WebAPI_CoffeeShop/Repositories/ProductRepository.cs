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
                query = context.Products.Where(p => p.isActive == 1)
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
                query = context.Products.Where(p => p.id.Equals(idProd) & p.isActive == 1)
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

        public List<ProductView> SearchProductsByKeyWord(string keyword)
        {
            List<ProductView> query;
            if (keyword != null)
            {
                using (var context = new CoffeeShopSystemEntities())
                {
                    query = context.Products.Where(p => (p.title.Contains(keyword) || p.Category.title.Contains(keyword) || p.Supplier.title.Contains(keyword)) & p.isActive == 1)
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
            else
            {
                query = GetProducts();
            }
            return query;

        }

        public List<ProductView> SearchProductsByCategory(string lsIdCategory)
        {
            List<ProductView> query;
            if (lsIdCategory != null)
            {
                using (var context = new CoffeeShopSystemEntities())
                {
                    query = context.Products.Where(p => lsIdCategory.Contains(p.idcate.ToString()) & p.isActive == 1)
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
            }
            else
            {
                query = GetProducts();
            }

            return query;
        }

        public List<ProductView> SearchProductsByPrice(int typePrice)
        {
            List<ProductView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                if (typePrice == 1)
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
                        }).OrderByDescending(p => p.finalPrice).ToList();
                }
                else if(typePrice==2)
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
                        }).OrderBy(p => p.finalPrice).ToList();
                } else
                {
                    query = GetProducts();
                }
            }
            return query;
        }
    }
}