using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class CategoryView
    {
        public int id { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<bool> isActive { get; set; }
        public int amountProductOfCate { get; set; }
    }
}