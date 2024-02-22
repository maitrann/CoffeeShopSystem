using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class CommentBlogRepository : ICommentRepository
    {
        public List<CommentBlogView> GetAllCommentBlog(int id)
        {
            List<CommentBlogView> query;

            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Comment_MnC_Type(id).Select(c => new CommentBlogView()
                {
                    id = c.id,
                    idBlog = c.idBlog,
                    idAccount = c.idAccount,
                    comment = c.comment,
                    dateCreate = c.dateCreate.ToString(),
                    indC = c.indC,
                    mnC = c.mnC,
                    status = c.status,
                    userType = c.userType,
                    timeSpace = c.timeSpace,
                    userName = c.userName,
                    statusType = c.statusType,
                    userAvatar = c.userAvatar,
                    lsSubComment = GetSubCommentBlog(id, c.id),
                    countSubComment = GetSubCommentBlog(id, c.id).Count(),
                }).ToList();
            }
            return query;
        }
        public List<SubCommentBlogView> GetSubCommentBlog(int idBlog, int? idMnC)
        {
            List<SubCommentBlogView> query = new List<SubCommentBlogView>();

            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Comment_SubC_Type(idBlog, idMnC).Select(c => new SubCommentBlogView()
                {
                    id = c.id,
                    idBlog = c.idBlog,
                    idAccount = c.idAccount,
                    comment = c.comment,
                    dateCreate = c.dateCreate.ToString(),
                    indC = c.indC,
                    mnC = c.mnC,
                    status = c.status,
                    userType = c.userType,
                    timeSpace = c.timeSpace,
                    userName = c.userName,
                    userAvatar = c.userAvatar,
                    userReply = c.userReply,
                }).ToList();
            }
            return query;
        }
        public Comment_SubC_Type_Result InsertCommentBlog(Comment_SubC_Type_Result model)
        {
            Comment_SubC_Type_Result subC = new Comment_SubC_Type_Result();
            using (var context = new CoffeeShopSystemEntities())
            {
                var comment = new CommentBlog()
                {
                    idBlog = model.idBlog,
                    idAccount = model.idAccount,
                    comment = model.comment,
                    dateCreate = DateTime.Now,
                    status = 1,
                    userType = model.userType,
                };
                if (model.idReply != 0)
                {
                    comment.mnC = model.idReply;
                    var callMaxInd = context.Comment_MaxIndC(model.idMainComment, model.idBlog).FirstOrDefault();
                    comment.indC = callMaxInd + 1;
                }
                else
                {
                    comment.mnC = 0;
                    comment.indC = 0;
                }
                context.CommentBlogs.Add(comment);
                context.SaveChanges();
                var key = context.CommentBlogs.Select(c => c.id).OrderByDescending(id => id).FirstOrDefault();
                if (model.idReply != 0)
                {
                    subC = context.GetCommentSub(key).Select(c=> new Comment_SubC_Type_Result()
                    {
                        id = c.id,
                        idBlog =c.idBlog,
                        idAccount =c.idAccount,
                        comment = c.comment,
                        dateCreate = c.dateCreate,
                        indC = c.indC,
                        mnC = c.mnC,
                        status = c.status,
                        userType = c.userType,
                        userName = c.userName,
                        userReply= c.userReply,
                        timeSpace = c.timeSpace,
                    }).FirstOrDefault();
                } else
                {
                    subC = context.GetCommentMain(key).Select(c => new Comment_SubC_Type_Result()
                    {
                        id = c.id,
                        idBlog = c.idBlog,
                        idAccount = c.idAccount,
                        comment = c.comment,
                        dateCreate = c.dateCreate,
                        indC = c.indC,
                        mnC = c.mnC,
                        status = c.status,
                        userType = c.userType,
                        userName = c.userName,
                        timeSpace = c.timeSpace,
                    }).FirstOrDefault();
                }
            }
            return subC;
        }

        
    }
}