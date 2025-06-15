using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public List<Review> GetReviewsOfProduct(int? idProduct)
        {
            List<Review> query;
            using (var context = new CoffeeShopSystemEntities())
            {
                query = context.Reviews.Where(r => r.idProduct == idProduct).ToList();
            }
            return query;
        }
        public double? avgReviewOfProduct(int? idProduct)
        {
            double? avgReview = 0;
            using (var context = new CoffeeShopSystemEntities())
            {
                avgReview = context.Reviews.Where(r => r.idProduct == idProduct).Average(r => r.review1) == null ? 0 : context.Reviews.Where(r => r.idProduct == idProduct).Average(r => r.review1);
            }
            return avgReview;
        }
        public int countReviewOfProduct(int? idProduct)
        {
            int countReview = 0;
            using (var context = new CoffeeShopSystemEntities())
            {
                countReview = context.Reviews.Where(r => r.idProduct == idProduct).Count();
            }
            return countReview;
        }
    }
}