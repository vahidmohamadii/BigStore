using BusinessLayer.Convertor;
using BusinessLayer.Dtos.Account;
using BusinessLayer.Services.InterFace;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SendEmail;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;

namespace BigStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _account;
        private readonly IViewRenderService _viewRender;

        public AccountController(IAccount account, IViewRenderService viewRender)
        {
            _account = account;
            _viewRender = viewRender;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
            {
            if (!ModelState.IsValid)
            {
                return View(register);

            }
            if (_account.IsEmailUnique(Trim.EmailTrim(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده تکراری است");
                return View(register);
            }
            if (_account.IsUserNameUnique(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده تکراری است");
                return View(register);
            }
            else
            {
                var userId=  _account.AddUser(register);
                DataLayer.Entities.User user=new DataLayer.Entities.User();
                var userForActiveCode=_account.FindUserByUserId(userId);
              
                var body= _viewRender.RenderToStringAsync("_ActiveAccountLink", userForActiveCode);
                SendEmail.SendEmail.Send(register.Email,"ایمیل فعالسازی", body);
                return RedirectToPage("_ActiveAccountLink");
            }

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            var user = _account.LoginUser(login);

            if (user != null)
            {
                if (user.IsActive)
                  {
                   var claims = new List<Claim>()
                   {
                       new Claim(ClaimTypes.Name,login.UserName)

                   };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var property = new AuthenticationProperties()
                    {
                        IsPersistent = login.IsPersistant
                    };

                    HttpContext.SignInAsync(principal, property);
                    return Redirect("https://localhost:44363");
                }
                else
                {
                    ModelState.AddModelError("IsActive", "حساب کاربری شما غیر فعال است");
                    return View(login);
                }
            }

            else
            {
                ModelState.AddModelError("", "شما ثبت نام نکرده اید");
                return View(login);
            }


        }


        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("https://localhost:44363");
        }

        public IActionResult ActiveAccount(string code)
        {
            _account.ActiveAccount(code);
            return Redirect("https://localhost:44363") ;
        }

    }
}
