using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;

namespace SocialMedia.Web.Controllers
{
    public class ProfileController : Controller
    {
        SocialMediaDbContext _dbcontext;
        int UserId;
        IHttpContextAccessor _httpContextAccessor;



        public ProfileController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _dbcontext = new SocialMediaDbContext();

            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            UserId = Int32.Parse(cookievalue);
        }

        [Authorize]
        public IActionResult Index()
        {
            try
            {
                var model = _dbcontext.User.Include(s => s.ToFriends).Include(s => s.FromFriends).Include(s => s.Posts)
                .ThenInclude(s => s.Comments).ThenInclude(s => s.User).Single(s => s.Id == UserId);


                return View(model);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        [Authorize]
        [Route("/profile/{username}")]
        public IActionResult Index(string username)
        {
            try
            {
                var model = _dbcontext.User.Include(s => s.ToFriends).Include(s => s.FromFriends).Include(s => s.Posts)
                .ThenInclude(s => s.Comments).ThenInclude(s => s.User).Single(s => s.Username == username);


                return View(model);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}