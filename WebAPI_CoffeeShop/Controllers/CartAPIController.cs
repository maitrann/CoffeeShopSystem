using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Repositories;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Controllers
{
    public class CartAPIController : ApiController
    {
        private ICartRepository _cartRepository = new CartRepository();

        [HttpGet]
        public List<CartView> GetCart(int idAccount)
        {
            return _cartRepository.GetCart(idAccount);
        }
        [HttpGet]
        public List<CartView> GetCartHover(int idAccount)
        {
            return _cartRepository.GetCartHover(idAccount);
        }
        [HttpPost]
        public void UpdateInsertCart([FromBody] Cart model)
        {
            _cartRepository.UpdateInsertCart(model);
        }
        [HttpGet]
        public void UpdateCart(int idCart, int amount, decimal? price)
        {
            _cartRepository.UpdateCart(idCart, amount, price);
        }
        [HttpGet]
        public void DeleteCart(int idCart)
        {
            _cartRepository.DeleteCart(idCart);
        }
        [HttpGet]
        public List<CartView> GetCartCheckout(int idAccount, string lsCartCheckout)
        {
            return _cartRepository.GetCartCheckout(idAccount, lsCartCheckout);
        }
        [HttpGet]
        public int quantityCartOfUser(int idAccount)
        {
            return _cartRepository.quantityCartOfUser(idAccount);
        }
        [HttpGet]
        public void UpdateCartCheckout(string lsIdCart)
        {
            _cartRepository.UpdateCartCheckout(lsIdCart);
        }

    }
}
