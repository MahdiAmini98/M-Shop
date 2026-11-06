using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using M_Shop.Data.Repository;
using M_Shop.Models;
using M_Shop.Models.View_Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace M_Shop.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _repository;

        public AccountController(IUserRepository repository)
        {
            _repository = repository;
        }


        #region Register


        //برای ثبت نام کاربر
        public IActionResult Register()
        {
            return View();

        }

        [HttpPost]


        //برای ثبت نام کاربر
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);

            }

            if (_repository.IsExistEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است");
                return View(register);
            }

            Users users=new Users()
            {
                Email = register.Email,
                Password = register.Password,
                IsAdmin = false,
                RegisterDateTime = DateTime.Now
            };

            _repository.AddUser(users);

            return View("SuccsesRegister",register);
        }

        #endregion

        #region Login

        //برای ورود کاربر به حساب کاریری
        public IActionResult Login()
        {
            return View();
        }


        //برای ورود کاربر به حساب کاریری
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _repository.GetUserForLogin(login.Email.ToLower(), login.Password);
            if (user==null)
            {
                ModelState.AddModelError("Email","اطلاعات صحیح نیست");
                return View(login);
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("IsAdmin", user.IsAdmin.ToString()),
               

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.ReMemberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");

        }


        #endregion

        #region Logout

        //این کنترلر برای خروج کاربر از حساب کاربری است
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");


        }

        #endregion
    }
}
