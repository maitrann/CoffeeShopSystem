using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.CallRESTful;

namespace WebMVC_CoffeeShopSystem.Repositories
{
    public class CartDao
    {
        private CartDao() { }
        private static readonly CartDao obj = new CartDao();
        private static CartDao instance = null;
        public static CartDao Instance
        {
            get
            {
                if (instance == null) // Thread Safety Singleton using Double-Check Locking
                {
                    lock (obj) // Thread Safety Singleton
                    {
                        if (instance == null)
                        {
                            instance = new CartDao();
                        }
                    }
                }
                return instance;
            }
        }
        public List<CartView> getCart(int idAccount)
        {
            return CartCall.Instance.getCart(idAccount);
        }
        public void UpdateInsertCart(Cart model)
        {
            CartCall.Instance.UpdateInsertCart(model);
        }
        public void UpdateCart(int idCart, int amount, decimal? price)
        {
            CartCall.Instance.UpdateCart(idCart, amount, price);
        }
        public void DeleteCart(int idCart)
        {
            CartCall.Instance.DeleteCart(idCart);
        }
        public List<CartView> GetCartCheckout(int idAccount, string lsCartCheckout)
        {
            return CartCall.Instance.GetCartCheckout(idAccount, lsCartCheckout);
        }
        public void UpdateCartCheckout(string lsIdCart)
        {
            CartCall.Instance.UpdateCartCheckout(lsIdCart);
        }
        public int quantityCartOfUser(int idAccount)
        {
            return CartCall.Instance.quantityCartOfUser(idAccount);
        }
    }
}