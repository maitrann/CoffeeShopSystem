using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Interface
{
    internal interface IReviewRepository
    {
        List<Review> GetReviewsOfProduct(int? idProduct);
        double? avgReviewOfProduct(int? idProduct);
        int countReviewOfProduct(int? idProduct);
    }
}
