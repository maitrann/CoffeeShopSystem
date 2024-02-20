using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                return View();
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
                var idUser = 7;
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

    }
}