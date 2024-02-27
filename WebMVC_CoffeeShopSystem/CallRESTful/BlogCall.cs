using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using WebAPI_CoffeeShop.Models.ModelView;
using WebMVC_CoffeeShopSystem.BaseURL;
using WebAPI_CoffeeShop.Utilities;

namespace WebMVC_CoffeeShopSystem.CallRESTful
{
    public class BlogCall
    {
        BlogCall() { }
        private static BlogCall instance = null;
        public static BlogCall Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BlogCall();
                }
                return instance;
            }
        }

        public IEnumerable<BlogView> GetAllBlog()
        {
            List<BlogView> prodInfo = new List<BlogView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(blogUrl.GetBlog).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<BlogView>>(prodResponse);
                }
                return prodInfo;
            }
        }
        public IEnumerable<BlogView> SearchBlogByKeyword(string keyword)
        {
            List<BlogView> prodInfo = new List<BlogView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(blogUrl.SearchBlogByKeyword + "?keyword=" + keyword).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<BlogView>>(prodResponse);
                }
                return prodInfo;
            }
        }
        public BlogView GetBlogById(int? idBlog)
        {
            BlogView prodInfo = new BlogView();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(blogUrl.GetBlogById + "?idBlog=" + idBlog).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<BlogView>(prodResponse);
                }
                return prodInfo;
            }
        }
        public List<CommentBlogView> GetCommentBlogById(int? id)
        {
            List<CommentBlogView> prodInfo = new List<CommentBlogView>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(blogUrl.GetCommentBlogById + "?id=" + id).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    prodInfo = JsonConvert.DeserializeObject<List<CommentBlogView>>(prodResponse);
                }
                return prodInfo;
            }
        }
        public Comment_SubC_Type_Result InsertCommentBlog(Comment_SubC_Type_Result model)
        {
            Comment_SubC_Type_Result comment = new Comment_SubC_Type_Result();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.PostAsJsonAsync(blogUrl.InsertCommentBlog, model).GetAwaiter().GetResult();
                if (Res.IsSuccessStatusCode)
                {
                    var prodResponse = Res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    comment = JsonConvert.DeserializeObject<Comment_SubC_Type_Result>(prodResponse);
                }
                return comment;
            }
        }
    }
}