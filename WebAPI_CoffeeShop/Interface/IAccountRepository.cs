using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Interface
{
    internal interface IAccountRepository
    {
        bool CheckAccountExistUsername(string username);
        bool CheckAccountExistEmail(string email);
        bool CheckAccountExistPhone(string phone);
        AccountView SignUpAccount(Account model);
        AccountView SignInAccount(string email, string password);
    }
}
