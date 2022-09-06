using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyEshop_2.Data.Repositories;
using MyEshop_2.Models;
using System.Security.Claims;

namespace MyEshop_2.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        #region Register

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
            //if (_userRepository.IsExistUserByEmail(register.Email.ToLower()))
            //{
            //    ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است");
            //    return View(register);
            //}

            Users user = new Users()
            {
                Email = register.Email.ToLower(),
                Password = register.Password,
                IsAdmin = false,
                RegisterDate = DateTime.Now,
            };
            _userRepository.AddUser(user);

            return View("SuccessRegister", register);


        }

        public IActionResult CheckEmail(string email)
        {
            if (_userRepository.IsExistUserByEmail(email.ToLower()))
            {
                return Json($"ایمیل {email} قبلا ثبت نام کرده است");
            }

                return Json(true);
        }

        #endregion


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _userRepository.GetUserForLogin(login.Email, login.Password);
            if(user == null)
            {
                ModelState.AddModelError("Email", "کاربری با این مشخصات یافت نشد");
                return View(login);
            }
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("isadmin",user.IsAdmin.ToString())
            };
            var identity = new ClaimsIdentity(Claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties()
            {
                IsPersistent= login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
