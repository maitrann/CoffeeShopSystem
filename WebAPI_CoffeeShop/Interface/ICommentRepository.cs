using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Interface
{
    internal interface ICommentRepository
    {
        List<CommentBlogView> GetAllCommentBlog(int id);
        Comment_SubC_Type_Result InsertCommentBlog(Comment_SubC_Type_Result model);

    }
}
