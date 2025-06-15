using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.Repositories;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Index()
        {
            ViewBag.lstBlog = BlogDao.Instance.GetAllBlog();
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                ViewBag.idBlog = id;
                ViewBag.detailsBlog = BlogDao.Instance.GetBlogById(id);
                if (BlogDao.Instance.GetBlogById(id) != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult GetCommentBlogById(int? id)
        {
            if (id != null)
            {
                int idUser = 0;
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    idUser = reqCookies["userId"].ToString().AsInt();
                }
                else
                {
                    idUser = -1;
                }
                ViewBag.idBlog = id;
                ViewBag.commentsBlog = BlogDao.Instance.GetCommentBlogById(id);
                ViewBag.crrUser = idUser;
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult InsertMainCommentBlog(int idBlog, string content)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];

            var idUser = reqCookies["userId"].ToString().AsInt();
            Comment_SubC_Type_Result subC = new Comment_SubC_Type_Result();
            subC.idAccount = idUser.ToString();
            subC.idBlog = idBlog;
            subC.comment = content;
            subC.userType = 2;

            subC = BlogDao.Instance.InsertCommentBlog(subC);
            ViewBag.subC = subC;
            ViewBag.crrUser = idUser;
            return PartialView();
        }
        public ActionResult InsertSubCommentBlog(int idBlog, int idReply, string content, int idMainB)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];

            var idUser = reqCookies["userId"].ToString().AsInt();
            Comment_SubC_Type_Result subC = new Comment_SubC_Type_Result();
            subC.idAccount = idUser.ToString();
            subC.idBlog = idBlog;
            subC.idReply = idReply;
            subC.comment = content;
            subC.idMainComment = idMainB;
            subC.userType = 2;

            subC = BlogDao.Instance.InsertCommentBlog(subC);
            ViewBag.subC = subC;
            ViewBag.crrUser = idUser;
            ViewBag.idMainB = idMainB;
            return PartialView();
        }
    }
}
