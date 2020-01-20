using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using SocialMedia.Model;
using SocialMedia.Web.Models;

namespace SocialMedia.Web.Controllers
{
    public class SearchController : Controller
    {
        SocialMediaDbContext _dbcontext;
        int UserId;
        IHttpContextAccessor _httpContextAccessor;


        public SearchController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _dbcontext = new SocialMediaDbContext();

            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            UserId = Int32.Parse(cookievalue);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index(string searchtext)
        {
            try
            {
                var userlist = _dbcontext.User.Include(s => s.FromFriends).ThenInclude(s => s.FromUser).Include(s => s.ToFriends)
                .ThenInclude(s => s.ToUser).Where(c => c.Name.Contains(searchtext) || c.Surname.Contains(searchtext) || c.Username.Contains(searchtext));
                SearchIndex model = new SearchIndex()
                {
                    Model = userlist.ToList(),
                    UserId = UserId
                };


                return View(model);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}