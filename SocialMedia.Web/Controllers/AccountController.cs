using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Data;
using SocialMedia.Web.Models;
using SocialMedia.Application.User;

namespace SocialMedia.Web.Controllers
{
    [ValidateAntiForgeryToken]
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public AccountController(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {

            var userHasExist = await _userService.UserHasExist(registerModel.Username);

            if (!userHasExist)
            {

                var userModel = new Model.User
                {
                    Username = registerModel.Username,
                    Password = registerModel.Password,
                    Email = registerModel.Email,
                    Name = registerModel.Name,
                    Surname = registerModel.Surname,
                    PhotoPath = "default-pp.jpg"
                };

                await _userService.AddUser(userModel);

            }
            else
            {
                throw new Exception("User has exist");
            }

            return RedirectToAction("Login", "Account");
        }
    


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {

            var userHasLogin = await _userService.LoginUser(loginModel.Username, loginModel.Password);

            if (userHasLogin)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginModel.Username)
                };

                var userId = await _userService.GetUserIdByUserName(loginModel.Username);

                var userIdentity = new ClaimsIdentity(claims, "cookie");

                HttpContext.Response.Cookies.Delete("CookieSchema");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await _httpContextAccessor.HttpContext.SignInAsync("CookieSchema", principal);
                _httpContextAccessor.HttpContext.Response.Cookies.Append("UserId", userId.ToString());

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync("CookieSchema");
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("UserId");
            return RedirectToAction("Login");
        }

    }
}
