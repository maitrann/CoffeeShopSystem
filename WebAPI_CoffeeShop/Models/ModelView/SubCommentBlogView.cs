using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class SubCommentBlogView
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> idBlog { get; set; }
        public string idAccount { get; set; }
        public string comment { get; set; }
        public string dateCreate { get; set; }
        public Nullable<int> indC { get; set; }
        public Nullable<int> mnC { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> userType { get; set; }
        public Nullable<int> timeSpace { get; set; }
        public string userName { get; set; }
        public string userAvatar { get; set; }
        public string userReply { get; set; }
    }
}