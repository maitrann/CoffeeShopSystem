using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Repositories;

namespace WebAPI_CoffeeShop.Controllers
{
    public class BlogAPIController : ApiController
    {
        private IBlogRepository _blogRepository = new BlogRepository();

        [HttpGet]
        public IEnumerable<BlogView> GetAllBlog()
        {
            return _blogRepository.GetAllBlog();
        }
        [HttpGet]
        public BlogView GetBlogById(int idBlog)
        {
            return _blogRepository.GetBlogById(idBlog);
        }
        [HttpGet]
        public IEnumerable<BlogView> SearchBlogByKeyword(string keyword)
        {
            return _blogRepository.SearchBlogByKeyword(keyword);
        }

    }
}
