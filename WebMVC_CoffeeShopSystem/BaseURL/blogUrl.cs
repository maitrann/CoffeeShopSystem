using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class blogUrl
    {
        public static string GetBlog = "http://localhost:63566/api/BlogAPI/GetAllBlog";
        public static string SearchBlogByKeyword = "http://localhost:63566/api/BlogAPI/SearchBlogByKeyword";

        public static string GetBlogById = "http://localhost:63566/api/BlogAPI/GetBlogById";
        public static string GetCommentBlogById = "http://localhost:63566/api/CommentAPI/GetAllCommentBlog";
        public static string InsertCommentBlog = "http://localhost:63566/api/CommentAPI/InsertCommentBlog";

    }
}