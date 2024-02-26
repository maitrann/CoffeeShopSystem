using PayPal.Api.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebAPI_CoffeeShop.Models.ModelView;
using WebAPI_CoffeeShop.Utilities;
using WebMVC_CoffeeShopSystem.Dao;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class SigninController : Controller
    {
        // GET: Signin
        public ActionResult Index()
        {
            var response = GoogleAuthDao.Instance.connectGoogleAuth();
            ViewBag.response = response;
            ViewBag.modeForm = "";
            return View();
        }
        [Route("Signup")]
        public ActionResult Signup()
        {
            var response = GoogleAuthDao.Instance.connectGoogleAuth();
            ViewBag.response = response;
            ViewBag.modeForm = "right-panel-active";
            return View("Index");
        }

        public async Task<ActionResult> GoogleLoginCallBack(string code)
        {
            if (code != null)
            {
                var userProfile = await GoogleAuthDao.Instance.GoogleLoginCallBack(code);
                TempData["shortMessageSignin"] = "Successfully authenticated from Google account.";
                AccountView signup = SignUpAccount("BLANK", "BLANK", userProfile.name, "BLANK", userProfile.email);
                if(signup == null)
                {
                    TempData["msgSignin"] = "false";
                    return RedirectToAction("Index");
                }
                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo["userId"] = signup.id.ToString();
                userInfo["userName"] = signup.name.ToString();
                Response.Cookies.Add(userInfo);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public AccountView SignUpAccount(string username, string password, string name, string phone, string email)
        {
            Account model = new Account();
            model.avatar = "NoImage";
            model.username = username;
            model.password = password;
            model.phone = phone;
            model.name = name;
            model.email = email;
            model.createDate = DateTime.Now;
            model.isActive = true;
            model.saltKey = "BLANK";
            AccountView check = AccountDao.Instance.SignUpAccount(model);
            return check;
        }
        public string SignInAccount(string email, string password)
        {
            AccountView check = AccountDao.Instance.SignInAccount(email, password);
            if (check != null)
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo["userId"] = check.id.ToString();
                userInfo["userName"] = check.name.ToString();
                Response.Cookies.Add(userInfo);
                return "True";
            }
            else
            {
                return "False";
            }
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [Route("Logout")]
        public ActionResult Logout()
        {
            HttpCookie myCookie = new HttpCookie("userInfo");
            //Here, we are setting the time to a previous time.
            //When the browser detect it next time, it will be deleted automatically.
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
            return RedirectToAction("Index", "Home");
        }
        public string CheckAccountExistUsername(string username)
        {
            var check = AccountDao.Instance.CheckAccountExistUsername(username);
            return check.ToString();
        }
        public string CheckAccountExistEmail(string email)
        {
            var check = AccountDao.Instance.CheckAccountExistEmail(email);
            return check.ToString();
        }
        public bool CheckAccountExistPhone(string phone)
        {
            var check = AccountDao.Instance.CheckAccountExistPhone(phone);
            return check;
        }
    }
}