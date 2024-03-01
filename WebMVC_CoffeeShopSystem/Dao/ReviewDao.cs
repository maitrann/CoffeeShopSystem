using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.CallRESTful;

namespace WebMVC_CoffeeShopSystem.Dao
{
    public class ReviewDao
    {
        private ReviewDao() { }
        private static readonly ReviewDao obj = new ReviewDao();
        private static ReviewDao instance = null;
        public static ReviewDao Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new ReviewDao();
                        }
                    }
                }
                return instance;
            }
        }
        public List<Review> GetReviewsOfProduct(int? idProduct)
        {
            return ReviewCall.Instance.GetReviewsOfProduct(idProduct);
        }
        public double? avgReviewOfProduct(int? idProduct)
        {
            return ReviewCall.Instance.avgReviewOfProduct(idProduct);
        }
        public int countReviewOfProduct(int? idProduct)
        {
            return ReviewCall.Instance.countReviewOfProduct(idProduct);
        }
    }
}