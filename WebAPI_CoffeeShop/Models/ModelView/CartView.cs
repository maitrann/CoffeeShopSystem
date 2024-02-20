using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class CartView
    {
        public int? idSupplier { get; set; }
        public string titleSupplier { get; set; }
        public int idCart { get; set; }
        public Nullable<int> idAccount { get; set; }
        public Nullable<int> idProduct { get; set; }
        public string titleProd { get; set; }
        public string imageProd { get; set; }
        public Nullable<int> Amount { get; set; }
        public decimal? UnitPrice { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Status { get; set; }
        public List<CartView> cartViews { get; set; }

    }
}