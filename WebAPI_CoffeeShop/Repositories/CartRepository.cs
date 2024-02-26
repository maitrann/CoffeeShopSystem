using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class CartRepository : ICartRepository
    {

        public List<CartView> GetCart(int idAccount)
        {
            List<CartView> query = new List<CartView>();
            var distinctSuppCart = GetDistinctSupplierCart(idAccount);
            foreach (var s in distinctSuppCart)
            {
                CartView item = new CartView();
                item.idSupplier = s.idSupplier;
                item.titleSupplier = s.titleSupplier;
                var prodSuppCart = GetProductOfSupplierCart(idAccount, s.idSupplier);
                item.cartViews = prodSuppCart;
                query.Add(item);
            }
            return query.OrderByDescending(q => q.idCart).ToList();
        }
        public List<CartView> GetCartHover(int idAccount)
        {
            List<CartView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Carts.Where(c => c.idAccount == idAccount & c.Status == true & c.Product.isActive == 1)
                    .Select(c => new CartView()
                    {
                        idCart = c.id,
                        idAccount = c.idAccount,
                        idProduct = c.idProduct,
                        titleProd = c.Product.title,
                        imageProd = c.Product.image,
                        UnitPrice = c.Price / c.Amount,
                        Amount = c.Amount,
                        Price = c.Price,
                        Status = c.Status,
                    }).OrderByDescending(c => c.idCart).Take(4).ToList();
            }
            return query;
        }
        public void UpdateInsertCart(Cart model)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var cart = context.Carts.Where(c => c.idAccount==model.idAccount & c.idProduct == model.idProduct & c.Status == true).FirstOrDefault();
                if (cart != null)
                {
                    var cartAmountOld = cart.Amount;
                    //update cart
                    cart.Amount += model.Amount;
                    if (cart.Amount >= 50)
                    {
                        cart.Amount = 50;
                        cart.Price = (cart.Price / cartAmountOld) * 50;
                    }
                    else
                    {
                        cart.Price += model.Price;
                    }
                    context.SaveChanges();
                }
                else
                {
                    //insert cart
                    context.Carts.Add(model);
                    context.SaveChanges();
                }
            }
        }
        public void UpdateCart(int idCart, int amount, decimal? price)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var cart = context.Carts.Where(c => c.id == idCart & c.Status == true).FirstOrDefault();
                cart.Amount = amount;
                cart.Price = price;
                context.SaveChanges();
            }
        }
        public void DeleteCart(int idCart)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var cart = context.Carts.Where(c => c.id == idCart).FirstOrDefault();
                context.Carts.Remove(cart);
                context.SaveChanges();
            }
        }
        public List<CartView> GetCartCheckout(int idAccount, string lsCartCheckout)
        {
            List<CartView> query = new List<CartView>();
            var distinctSuppCart = GetDistinctSupplierCartCheckout(idAccount, lsCartCheckout);
            foreach (var s in distinctSuppCart)
            {
                CartView item = new CartView();
                item.idSupplier = s.idSupplier;
                item.titleSupplier = s.titleSupplier;
                var prodSuppCart = GetProductOfSupplierCartCheckout(idAccount, s.idSupplier, lsCartCheckout);
                item.cartViews = prodSuppCart;
                query.Add(item);
            }
            return query.OrderByDescending(q => q.idCart).ToList();
        }
        public int quantityCartOfUser(int idAccount)
        {
            int query = 0;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Carts.Where(c => c.idAccount == idAccount & c.Status == true).Count();
            }
            return query;
        }
        public void UpdateCartCheckout(string lsIdCart)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var cart = context.Carts.Where(c => lsIdCart.Contains(c.id.ToString())).ToList();
                foreach (var item in cart)
                {
                    item.Status = false;
                    context.SaveChanges();
                }
            }
        }

        private List<CartView> GetDistinctSupplierCartCheckout(int idAccount, string lsCartCheckout)
        {
            List<CartView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Carts.Where(c => c.idAccount == idAccount & c.Status == true & c.Product.isActive == 1 & lsCartCheckout.Contains(c.id.ToString()))
                    .Select(c => new CartView()
                    {
                        idSupplier = c.Product.idSupplier,
                        titleSupplier = c.Product.Supplier.title,
                    }).Distinct().ToList();
            }
            return query;
        }
        private List<CartView> GetProductOfSupplierCartCheckout(int idAccount, int? idSupplier, string lsCartCheckout)
        {
            List<CartView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Carts.Where(c => c.Product.idSupplier == idSupplier & c.idAccount == idAccount & c.Status == true & c.Product.isActive == 1 & lsCartCheckout.Contains(c.id.ToString()))
                    .Select(c => new CartView()
                    {
                        idCart = c.id,
                        idAccount = c.idAccount,
                        idProduct = c.idProduct,
                        titleProd = c.Product.title,
                        imageProd = c.Product.image,
                        UnitPrice = c.Price / c.Amount,
                        Amount = c.Amount,
                        Price = c.Price,
                        Status = c.Status,
                    }).ToList();
            }
            return query;
        }

        private List<CartView> GetDistinctSupplierCart(int idAccount)
        {
            List<CartView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Carts.Where(c => c.idAccount == idAccount & c.Status == true & c.Product.isActive == 1)
                    .Select(c => new CartView()
                    {
                        idSupplier = c.Product.idSupplier,
                        titleSupplier = c.Product.Supplier.title,
                    }).Distinct().ToList();
            }
            return query;
        }
        private List<CartView> GetProductOfSupplierCart(int idAccount, int? idSupplier)
        {
            List<CartView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Carts.Where(c => c.Product.idSupplier == idSupplier & c.idAccount == idAccount & c.Status == true & c.Product.isActive == 1)
                    .Select(c => new CartView()
                    {
                        idCart = c.id,
                        idAccount = c.idAccount,
                        idProduct = c.idProduct,
                        titleProd = c.Product.title,
                        imageProd = c.Product.image,
                        UnitPrice = c.Price / c.Amount,
                        Amount = c.Amount,
                        Price = c.Price,
                        Status = c.Status,
                    }).ToList();
            }
            return query;
        }
    }
}