using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Message;
using SocialMedia.Application.User;
using SocialMedia.Data;
using SocialMedia.Model;
using SocialMedia.Web.Models;

namespace SocialMedia.Web.Controllers
{
    [Authorize]
    [ValidateAntiForgeryToken]
    public class MessageController : Controller
    {


        private readonly int _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public MessageController(IHttpContextAccessor httpContextAccessor,
            IUserService userService,
            IMessageService messageService)
        {
            _httpContextAccessor = httpContextAccessor;
            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            _userId = Int32.Parse(cookievalue);

            _userService = userService;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {

            var userList = await _userService.GetUsersWithMessages(_userId);

            var photoPath = await _userService.GetPhotoPath(_userId);

            var model = new IndexMessages()
            {
                UserList = userList,
                PPPath = photoPath
            };


            return View(model);

        }

        [HttpGet]
        public async Task<GetMessagesModel> GetMessages(int targetId)
        {

            var user = await _userService.GetUser(targetId);


            var messagelist = await _messageService.GetMessages(_userId, targetId);

            var model = new GetMessagesModel()
            {
                User = user,
                MessagesList = messagelist
            };

            return model;
 
        }


        [HttpPost]
        public void InsertMessage(string text,int targetId)
        {

            var message = new Message()
            {
                Text = text,
                FromUserId = _userId,
                ToUserId = targetId,
                Time = DateTime.Now
            };

            _messageService.AddMessage(message);



        }

        [HttpPost]
        public async Task<IActionResult> InsertMessageForPopup(string text, string userName)
        {


            int targetId = await _userService.GetUserIdByUserName(userName);


            var message = new Message()
            {
                Text = text,
                FromUserId = _userId,
                ToUserId = targetId,
                Time = DateTime.Now
            };

            await _messageService.AddMessage(message);

            return RedirectToAction("Index", "Message");

        }
    }
}