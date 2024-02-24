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
    public class AccountAPIController : ApiController
    {
        IAccountRepository _accountRepository = new AccountRepository();
        [HttpGet]
        public bool CheckAccountExistUsername(string username)
        {
            return _accountRepository.CheckAccountExistUsername(username);
        }
        [HttpGet]
        public bool CheckAccountExistEmail(string email)
        {
            return _accountRepository.CheckAccountExistEmail(email);
        }
        [HttpGet]
        public bool CheckAccountExistPhone(string phone)
        { 
            return _accountRepository.CheckAccountExistPhone(phone);
        }
        [HttpPost]
        public AccountView SignUpAccount([FromBody] Account model)
        {
            return _accountRepository.SignUpAccount(model);
        }
        [HttpGet]
        public AccountView SignInAccount(string email, string password)
        {
            return _accountRepository.SignInAccount(email, password);
        }

    }
}
