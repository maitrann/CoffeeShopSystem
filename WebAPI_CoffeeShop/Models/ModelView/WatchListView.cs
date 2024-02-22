using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class WatchListView
    {
        public int id { get; set; }
        public Nullable<int> idProduct { get; set; }
        public string titleProduct { get; set; }
        public string image { get; set; }
        public string image1 { get; set; }
        public int? idCate { get; set; }
        public string titleCate { get; set; }
        public decimal? price { get; set; }
        public decimal? priceCurr { get; set; }
        public Nullable<int> idAccount { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
    }
}