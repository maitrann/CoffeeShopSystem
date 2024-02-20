using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class ProductView
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string description { get; set; }
        public decimal? price { get; set; }
        public decimal? finalPrice { get; set; }
        public Nullable<int> idSupplier { get; set; }
        public Nullable<int> isActive { get; set; }
        public Nullable<int> idcate { get; set; }
        public string titleCate { get; set; }
        public decimal? discount { get; set; }
        public string titleSupplier { get; set; }
    }
}