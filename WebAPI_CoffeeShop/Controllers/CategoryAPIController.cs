using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Repositories;

namespace WebAPI_CoffeeShop.Controllers
{
    public class CategoryAPIController : ApiController
    {
        ICategoryRepository _categoryRepository = new CategoryRepository();
        [HttpGet]
        public List<CategoryView> GetMenuCategory()
        {
            return _categoryRepository.GetMenuCategory();
        }
    }
}
