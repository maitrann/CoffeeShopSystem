using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Interface
{
    internal interface ICartRepository
    {
        List<CartView> GetCart(int idAccount);
        List<CartView> GetCartHover(int idAccount);
        int UpdateInsertCart(Cart model);
        void UpdateCart(int idCart, int amount, decimal? price);
        bool DeleteCart(int idCart);
        List<CartView> GetCartCheckout(int idAccount, string lsCartCheckout);
        int quantityCartOfUser(int idAccount);
        void UpdateCartCheckout(string lsIdCart);
    }
}
