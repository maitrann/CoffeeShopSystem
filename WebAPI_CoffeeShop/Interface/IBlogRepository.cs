using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Models.ModelView;

namespace WebAPI_CoffeeShop.Interface
{
    internal interface IBlogRepository
    {
        IEnumerable<BlogView> GetAllBlog();
        BlogView GetBlogById(int idBlog);
        IEnumerable<BlogView> SearchBlogByKeyword(string keyword);
    }
}
