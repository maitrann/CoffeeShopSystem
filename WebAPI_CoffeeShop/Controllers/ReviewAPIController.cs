using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Repositories;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Controllers
{
    public class ReviewAPIController : ApiController
    {
        private IReviewRepository _reviewRepository = new ReviewRepository();

        [HttpGet]
        public IEnumerable<Review> GetReviewsOfProduct(int? idProduct)
        {
            return _reviewRepository.GetReviewsOfProduct(idProduct);
        }
        [HttpGet]
        public double? avgReviewOfProduct(int? idProduct)
        {
            return _reviewRepository.avgReviewOfProduct(idProduct);
        }
        [HttpGet]
        public int countReviewOfProduct(int? idProduct)
        {
            return _reviewRepository.countReviewOfProduct(idProduct);
        }
    }
}
