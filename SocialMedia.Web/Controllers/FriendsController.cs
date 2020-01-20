using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using SocialMedia.Web.Models;

namespace SocialMedia.Web.Controllers
{
    public class FriendsController : Controller
    {
        SocialMediaDbContext _dbcontext;
        int UserId;
        IHttpContextAccessor _httpContextAccessor;

        public FriendsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _dbcontext = new SocialMediaDbContext();

            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            UserId = Int32.Parse(cookievalue);
        }

        [Authorize]
        public IActionResult Index()
        {

           try {
                var model = new IndexFriends()
                {
                    PendingFriends = _dbcontext.Friend.Include(c => c.FromUser).Where(c => c.ToUserId == UserId && c.Status == 2).ToList(),
                    FriendsTo = _dbcontext.Friend.Include(c => c.FromUser).Include(c => c.ToUser).Where(c => (c.FromUserId == UserId) && c.Status == 1).ToList(),
                    FriendsFrom = _dbcontext.Friend.Include(c => c.FromUser).Include(c => c.ToUser).Where(c => (
                     c.ToUserId == UserId) && c.Status == 1).ToList()

                };

                return View(model);

            }
            catch(Exception e)
            {
                return null;
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]

        public bool Friends (int targetId,int status)
        {
           try
            {
                if (status == 2)
                {
                    _dbcontext.Friend.Add(new Model.Friend()
                    {
                        FromUserId = UserId,
                        ToUserId = targetId,
                        Status = status

                    });
                }
                else if (status == 1 || status == 0)
                {
                    var obj = _dbcontext.Friend.Single(c => c.ToUserId == UserId && c.FromUserId == targetId && c.Status == 2);
                    obj.Status = status;
                }
                else if(status == -1)
                {
                    var obj = _dbcontext.Friend.Single(c => (c.ToUserId == UserId && c.FromUserId == targetId) ||
                    (c.ToUserId == targetId && c.FromUserId == UserId));
                    _dbcontext.Friend.Remove(obj);

                }

                _dbcontext.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}