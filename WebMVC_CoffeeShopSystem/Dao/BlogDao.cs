using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.CallRESTful;

namespace WebMVC_CoffeeShopSystem.Repositories
{
    public class BlogDao
    {
        private BlogDao() { }
        private static readonly BlogDao obj = new BlogDao();
        private static BlogDao instance = null;
        public static BlogDao Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new BlogDao();
                        }
                    }
                }
                return instance;
            }
        }
        public IEnumerable<BlogView> GetAllBlog()
        {
            return BlogCall.Instance.GetAllBlog();
        }
        public BlogView GetBlogById(int? idBlog)
        {
            return BlogCall.Instance.GetBlogById(idBlog);
        }
        public List<CommentBlogView> GetCommentBlogById(int? id)
        {
            return BlogCall.Instance.GetCommentBlogById(id);
        }
    }
}