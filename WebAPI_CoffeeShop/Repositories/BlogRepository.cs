using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        public IEnumerable<BlogView> GetAllBlog()
        {
            IEnumerable<BlogView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Blogs.Where(b => b.isStatus == 1)
                    .Select(b => new BlogView()
                    {
                        id = b.id,
                        userCreate = b.userCreate,
                        titleUserCreate = b.userCreate != 0 ? context.Suppliers.Where(s => s.id == b.userCreate).Select(s => s.title).FirstOrDefault() : "Cafena",
                        title = b.title,
                        image = b.image,
                        description = b.description,
                        createDate = b.createDate.ToString(),
                        countCmt = context.CommentBlogs.Where(c => c.idBlog == b.id & c.status == 1).Count(),
                        isStatus = b.isStatus,
                    }).OrderByDescending(b => b.id).ToList();
            }
            return query;
        }

        public BlogView GetBlogById(int idBlog)
        {
            BlogView query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Blogs.Where(b => b.id == idBlog & b.isStatus == 1)
                    .Select(b => new BlogView()
                    {
                        id = b.id,
                        userCreate = b.userCreate,
                        titleUserCreate = b.userCreate != 0 ? context.Suppliers.Where(s => s.id == b.userCreate).Select(s => s.title).FirstOrDefault() : "Cafena",
                        title = b.title,
                        image = b.image,
                        description = b.description,
                        createDate = b.createDate.ToString(),
                        countCmt = context.CommentBlogs.Where(c => c.idBlog == idBlog & c.status == 1).Count(),
                        isStatus = b.isStatus,
                    }).FirstOrDefault();
            }
            return query;
        }
        public IEnumerable<BlogView> SearchBlogByKeyword(string keyword)
        {
            IEnumerable<BlogView> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Blogs.Where(b => b.title == keyword & b.isStatus == 1)
                    .Select(b => new BlogView()
                    {
                        id = b.id,
                        userCreate = b.userCreate,
                        titleUserCreate = b.userCreate != 0 ? context.Suppliers.Where(s => s.id == b.userCreate).Select(s => s.title).FirstOrDefault() : "Cafena",
                        title = b.title,
                        image = b.image,
                        description = b.description,
                        createDate = b.createDate.ToString(),
                        countCmt = context.CommentBlogs.Where(c => c.idBlog == b.id & c.status == 1).Count(),
                        isStatus = b.isStatus,
                    }).OrderByDescending(b => b.id).ToList();
            }
            return query;
        }
    }
}