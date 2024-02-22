using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Repositories;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Controllers
{
    public class CommentAPIController : ApiController
    {
        private ICommentRepository _commentRepository = new CommentBlogRepository();
        [HttpGet]
        public List<CommentBlogView> GetAllCommentBlog(int id)
        {
            return _commentRepository.GetAllCommentBlog(id);
        }
        [HttpPost]
        public Comment_SubC_Type_Result InsertCommentBlog([FromBody] Comment_SubC_Type_Result model)
        {
            return _commentRepository.InsertCommentBlog(model);
        }
    }
}
