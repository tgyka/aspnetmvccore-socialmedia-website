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

namespace SocialMedia.Web.Controllers
{
    public class AccountController : Controller
    {
        SocialMediaDbContext _dbcontext = new SocialMediaDbContext();

        private static int UserId;
        IHttpContextAccessor _httpContextAccessor;

        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            try
            {
                if(_dbcontext.User.Where(c=> c.Username == registerModel.Username).Count() == 0 )
                {
                    _dbcontext.User.Add(new Model.User()
                    {
                        Username = registerModel.Username,
                        Password = registerModel.Password,
                        Email = registerModel.Email,
                        Name = registerModel.Name,
                        Surname = registerModel.Surname,
                        PhotoPath = "default-pp.jpg"

                    });

                    _dbcontext.SaveChanges();
                }

              

                return RedirectToAction("Login", "Account");
            }

            catch (Exception e)
            {
                return null;
            }
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                if (LoginUser(loginModel.Username, loginModel.Password))
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.Username)
            };
                    UserId = _dbcontext.User.Single(c => c.Username == loginModel.Username).Id;

                    var userIdentity = new ClaimsIdentity(claims, "cookie");


                    HttpContext.Response.Cookies.Delete("CookieSchema");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await _httpContextAccessor.HttpContext.SignInAsync("CookieSchema", principal);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("UserId", UserId.ToString());


                    //Just redirect to our index after logging in. 
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync("CookieSchema");
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("UserId");
            return RedirectToAction("Login");
        }


        private bool LoginUser(string username, string password)
        {
            var count = _dbcontext.User.Where(c => c.Username == username && c.Password == password).Count();

            return count > 0 ? true : false;

        }

        public static int GetUserId()
        {
            return UserId;
        }
    }
}
