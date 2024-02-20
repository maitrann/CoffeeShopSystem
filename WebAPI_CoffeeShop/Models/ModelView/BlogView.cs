using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Models.ModelView
{
    public class BlogView
    {
        public int id { get; set; }
        public Nullable<int> userCreate { get; set; }
        public string titleUserCreate { get; set; }
        public string avatarUserCreate { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string createDate { get; set; }
        public Nullable<int> isStatus { get; set; }
        public int countCmt { get; set; }
        public virtual ICollection<CommentBlog> CommentBlogs { get; set; }
    }
}