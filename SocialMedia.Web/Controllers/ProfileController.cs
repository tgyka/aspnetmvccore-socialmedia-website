using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.User;
using SocialMedia.Data;

namespace SocialMedia.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly int _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public ProfileController(IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            _userId = Int32.Parse(cookievalue);

            _userService = userService;

        }

        public async Task<IActionResult> Index()
        {

            var userModel = await _userService.GetUserWithFriendsByUserId(_userId);

            return View(userModel);
        }

        [Route("/profile/{username}")]
        public async Task<IActionResult> Index(string userName)
        {

            var userModel = await _userService.GetUserWithFriendsByUsername(userName);

            return View(userModel);
        }
    }
}