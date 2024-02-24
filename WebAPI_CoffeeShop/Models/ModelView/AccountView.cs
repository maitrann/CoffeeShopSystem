using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class AccountView
    {
        public int id { get; set; }
        public string avatar { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string saltKey { get; set; }
    }
}