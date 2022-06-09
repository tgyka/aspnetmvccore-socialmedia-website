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
using SocialMedia.Model;
using SocialMedia.Web.Models;

namespace SocialMedia.Web.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly int _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public SearchController(IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            _userId = Int32.Parse(cookievalue);

            _userService = userService;

        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchText)
        {

            var searchResult = await _userService.SearchUser(searchText);

            SearchIndex model = new SearchIndex()
            {
                Model = searchResult,
                UserId = _userId
            };


            return View(model);
        }
    }
}