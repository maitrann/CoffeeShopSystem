using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebAPI_CoffeeShop.Interface;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;

namespace WebAPI_CoffeeShop.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public bool CheckAccountExistUsername(string username)
        {
            bool check = true;
            using (var context = new CoffeeShopSystemEntities())
            {
                check = context.Accounts.Where(a => a.username == username & a.isActive == true).Count() > 0;
            }
            return check;
        }
        public bool CheckAccountExistEmail(string email)
        {
            bool check = true;
            using (var context = new CoffeeShopSystemEntities())
            {
                check = context.Accounts.Where(a => a.email == email & a.isActive == true).Count() > 0;
            }
            return check;
        }
        public bool CheckAccountExistPhone(string phone)
        {
            bool check = true;
            using (var context = new CoffeeShopSystemEntities())
            {
                check = context.Accounts.Where(a => a.phone == phone).Count() > 0;
            }
            return check;
        }
        public AccountView SignUpAccount(Account model)
        {
            AccountView signin;
            using (var context = new CoffeeShopSystemEntities())
            {
                if (model.password == "BLANK")
                {
                    var check = CheckAccountExistEmail(model.email);
                    if (check == true)
                    {
                        signin = SignInAccount(model.email, model.password);
                        //return null;
                    }
                    else
                    {
                        context.Accounts.Add(model);
                        context.SaveChanges();
                        signin = SignInAccount(model.email, model.password);
                    }
                }
                else
                {
                    model.password = PasswordHasher.HashPassword(model.password);
                    context.Accounts.Add(model);
                    context.SaveChanges();
                    signin = new AccountView() { id = model.id, name = model.name };
                }
            }
            return signin;
        }
        public AccountView SignInAccount(string email, string password)
        {
            AccountView query;
            using (var context = new CoffeeShopSystemEntities())
            {
                if (password != "BLANK")
                {
                    var account = context.Accounts.FirstOrDefault(a => a.email == email & a.isActive == true);
                    if (account == null)
                    {
                        return null;
                    }

                    if (!PasswordHasher.VerifyPassword(password, account.password))
                    {
                        return null;
                    }

                    if (!PasswordHasher.IsHashed(account.password))
                    {
                        account.password = PasswordHasher.HashPassword(password);
                        context.SaveChanges();
                    }

                    query = new AccountView() { id = account.id, name = account.name };
                }
                else
                {
                    query = context.Accounts.Where(a => a.email == email & a.password == "BLANK" & a.isActive == true)
                        .Select(a => new AccountView() { id = a.id, name = a.name }).FirstOrDefault();

                }
            }
            return query;
        }
    }
}
