using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Friend;
using SocialMedia.Data;
using SocialMedia.Model;
using SocialMedia.Web.Models;

namespace SocialMedia.Web.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        private static int UserId;
        IHttpContextAccessor _httpContextAccessor;
        private readonly IFriendService _friendService;

        public FriendController(IHttpContextAccessor httpContextAccessor, IFriendService friendService)
        {
            _httpContextAccessor = httpContextAccessor;
            _friendService = friendService;
            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            UserId = Int32.Parse(cookievalue);


        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index()
        {

            var pendingFriends = await _friendService.GetFromUserByToUserId(UserId, FriendStatus.Pending);
            var friendsTo =  await _friendService.GetToUserByFromUserId(UserId, FriendStatus.Accepted);
            var friendsFrom = await _friendService.GetFromUserByToUserId(UserId, FriendStatus.Accepted);

            var model = new IndexFriends()
            {
                PendingFriends = pendingFriends,
                FriendsTo = friendsTo,
                FriendsFrom = friendsFrom

            };

            return View(model);

            }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<bool> Friends (int targetId,FriendStatus status)
        {

            if (status == FriendStatus.Pending)
            {

                var friendModel = new Friend
                {
                    FromUserId = UserId,
                    ToUserId = targetId,
                    Status = status
                };

                await _friendService.AddFriend(friendModel);

            }
            else if (status == FriendStatus.Accepted || status == FriendStatus.Declined)
            {
                var friendModel = new Friend
                {
                    FromUserId = UserId,
                    ToUserId = targetId,
                    Status = status
                };

                await _friendService.UpdateFriend(friendModel);

            }
            else if(status == FriendStatus.Removed)
            {
                await _friendService.RemoveFriend(UserId, targetId);

            }

            return true;
        }
    }
}