namespace WebMVC_CoffeeShopSystem.BaseURL
{
    public class blogUrl
    {
        public static string GetBlog = stringUrl.Build("api/BlogAPI/GetAllBlog");
        public static string SearchBlogByKeyword = stringUrl.Build("api/BlogAPI/SearchBlogByKeyword");
        public static string GetBlogById = stringUrl.Build("api/BlogAPI/GetBlogById");
        public static string GetCommentBlogById = stringUrl.Build("api/CommentAPI/GetAllCommentBlog");
        public static string InsertCommentBlog = stringUrl.Build("api/CommentAPI/InsertCommentBlog");
    }
}
