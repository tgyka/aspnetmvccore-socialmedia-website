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
    public class MessagesController : Controller
    {
        SocialMediaDbContext _dbcontext;
        int UserId;
        IHttpContextAccessor _httpContextAccessor;



        public MessagesController(IHttpContextAccessor httpContextAccessor)
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
                var model = new IndexMessages()
                {
                    UserList = _dbcontext.User.Include(s => s.ToMessages).Include(s => s.FromMessages).Where(c => c.ToMessages.Where(s => s.FromUserId == UserId).Count() != 0 ||
                 c.FromMessages.Where(s => s.ToUserId == UserId).Count() != 0).ToList(),
                    PPPath = _dbcontext.User.Single(c => c.Id == UserId).PhotoPath
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
        public GetMessagesModel GetMessages(int targetId)
        {
            try
            {
                var user = _dbcontext.User.Single(c => c.Id == targetId);

                var messagelist = _dbcontext.Message
                    .Where(c => (c.FromUserId == targetId && c.ToUserId == UserId) || (c.FromUserId == UserId && c.ToUserId == targetId))
                    .Select(c => new MessageModel
                    {
                        Id = c.Id,
                        FromUserId = c.FromUserId,
                        ToUserId = c.ToUserId,
                        Text = c.Text,
                        Time = c.Time
                    })
                    .ToList();

                var model = new GetMessagesModel()
                {
                    User = user,
                    MessagesList = messagelist
                };

                return model;
            }
            catch(Exception e)
            {
                return null;
            }
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]
        public void InsertMessage(string text,int targetId)
        {
           try
            {
                var message = new Message()
                {
                    Text = text,
                    FromUserId = UserId,
                    ToUserId = targetId,
                    Time = DateTime.Now
                };

                _dbcontext.Add(message);

                _dbcontext.SaveChanges();

            }
            catch(Exception e)
            {

            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]
        public IActionResult InsertMessageForPopup(string text, string username)
        {
          try
            {
                int targetId = _dbcontext.User.SingleOrDefault(c => c.Username == username).Id;

                var message = new Message()
                {
                    Text = text,
                    FromUserId = UserId,
                    ToUserId = targetId,
                    Time = DateTime.Now
                };

                _dbcontext.Add(message);

                _dbcontext.SaveChanges();
                return RedirectToAction("Index", "Messages");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Messages");

            }


        }
    }
}