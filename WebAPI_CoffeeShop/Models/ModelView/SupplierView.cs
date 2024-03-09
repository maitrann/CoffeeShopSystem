using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class SupplierView
    {
        public int id { get; set; }
        public string avatar { get; set; }
        public string image { get; set; }
        public string title { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> requestDate { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> isActive { get; set; }
        public string saltKey { get; set; }
    }
}