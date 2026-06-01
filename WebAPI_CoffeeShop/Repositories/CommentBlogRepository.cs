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
            using (var context = new CoffeeShopSystemEntities())
            {
                var comments = context.CommentBlogs
                    .Where(c => c.idBlog == id && c.status == 1)
                    .OrderBy(c => c.indC)
                    .ThenBy(c => c.id)
                    .ToList();
                var mainComments = comments
                    .Where(c => c.mnC == 0 || c.mnC == null)
                    .OrderByDescending(c => c.id)
                    .ToList();

                return mainComments.Select(c =>
                {
                    var subComments = GetSubCommentBlog(context, comments, id, c.id);
                    return new CommentBlogView()
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
                        timeSpace = GetTimeSpace(c.dateCreate),
                        userName = GetUserName(context, c.idAccount, c.userType),
                        statusType = GetUserStatus(context, c.idAccount, c.userType),
                        userAvatar = GetUserAvatar(context, c.idAccount, c.userType),
                        lsSubComment = subComments,
                        countSubComment = subComments.Count,
                    };
                }).ToList();
            }
        }
        public List<SubCommentBlogView> GetSubCommentBlog(int idBlog, int? idMnC)
        {
            using (var context = new CoffeeShopSystemEntities())
            {
                var comments = context.CommentBlogs
                    .Where(c => c.idBlog == idBlog && c.status == 1)
                    .ToList();
                return GetSubCommentBlog(context, comments, idBlog, idMnC);
            }
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
                    var callMaxInd = context.CommentBlogs
                        .Where(c => c.idBlog == model.idBlog && c.status == 1 && c.indC > 0)
                        .Select(c => (int?)c.indC)
                        .Max() ?? 0;
                    comment.indC = callMaxInd + 1;
                }
                else
                {
                    comment.mnC = 0;
                    comment.indC = 0;
                }
                context.CommentBlogs.Add(comment);
                context.SaveChanges();
                subC = ToCommentResult(context, comment);
            }
            return subC;
        }

        private List<SubCommentBlogView> GetSubCommentBlog(CoffeeShopSystemEntities context, List<CommentBlog> comments, int idBlog, int? idMnC)
        {
            return comments
                .Where(c => c.idBlog == idBlog && c.id != idMnC && IsReplyUnderMain(comments, c, idMnC))
                .OrderBy(c => c.indC)
                .ThenBy(c => c.id)
                .Select(c => new SubCommentBlogView()
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
                    timeSpace = GetTimeSpace(c.dateCreate),
                    userName = GetUserName(context, c.idAccount, c.userType),
                    userAvatar = GetUserAvatar(context, c.idAccount, c.userType),
                    userReply = GetReplyUserName(context, comments, c.mnC),
                }).ToList();
        }

        private bool IsReplyUnderMain(List<CommentBlog> comments, CommentBlog comment, int? idMainComment)
        {
            var current = comment;
            while (current.mnC != 0 && current.mnC != null)
            {
                if (current.mnC == idMainComment)
                {
                    return true;
                }
                current = comments.FirstOrDefault(c => c.id == current.mnC);
                if (current == null)
                {
                    return false;
                }
            }
            return false;
        }

        private Comment_SubC_Type_Result ToCommentResult(CoffeeShopSystemEntities context, CommentBlog comment)
        {
            var comments = context.CommentBlogs
                .Where(c => c.idBlog == comment.idBlog && c.status == 1)
                .ToList();

            return new Comment_SubC_Type_Result()
            {
                id = comment.id,
                idBlog = comment.idBlog,
                idAccount = comment.idAccount,
                comment = comment.comment,
                dateCreate = comment.dateCreate,
                indC = comment.indC,
                mnC = comment.mnC,
                status = comment.status,
                userType = comment.userType,
                userName = GetUserName(context, comment.idAccount, comment.userType),
                userAvatar = GetUserAvatar(context, comment.idAccount, comment.userType),
                userReply = GetReplyUserName(context, comments, comment.mnC),
                timeSpace = GetTimeSpace(comment.dateCreate),
            };
        }

        private string GetReplyUserName(CoffeeShopSystemEntities context, List<CommentBlog> comments, int? idReply)
        {
            var replyComment = comments.FirstOrDefault(c => c.id == idReply);
            return replyComment == null ? null : GetUserName(context, replyComment.idAccount, replyComment.userType);
        }

        private string GetUserName(CoffeeShopSystemEntities context, string idAccount, int? userType)
        {
            int id;
            if (!int.TryParse(idAccount, out id))
            {
                return "Guest";
            }

            if (userType == 2)
            {
                return context.Accounts.Where(a => a.id == id).Select(a => a.name ?? a.username).FirstOrDefault() ?? "Customer";
            }

            return context.Suppliers.Where(s => s.id == id).Select(s => s.title ?? s.username).FirstOrDefault() ?? "Cafena";
        }

        private string GetUserAvatar(CoffeeShopSystemEntities context, string idAccount, int? userType)
        {
            int id;
            if (!int.TryParse(idAccount, out id))
            {
                return null;
            }

            if (userType == 2)
            {
                return context.Accounts.Where(a => a.id == id).Select(a => a.avatar).FirstOrDefault();
            }

            return context.Suppliers.Where(s => s.id == id).Select(s => s.avatar).FirstOrDefault();
        }

        private int? GetUserStatus(CoffeeShopSystemEntities context, string idAccount, int? userType)
        {
            int id;
            if (!int.TryParse(idAccount, out id))
            {
                return null;
            }

            if (userType == 2)
            {
                var isActive = context.Accounts.Where(a => a.id == id).Select(a => a.isActive).FirstOrDefault();
                return isActive == true ? 1 : 0;
            }

            return context.Suppliers.Where(s => s.id == id).Select(s => s.isActive).FirstOrDefault();
        }

        private int? GetTimeSpace(DateTime? dateCreate)
        {
            if (dateCreate == null)
            {
                return null;
            }
            return (DateTime.Now.Date - dateCreate.Value.Date).Days;
        }
    }
}
