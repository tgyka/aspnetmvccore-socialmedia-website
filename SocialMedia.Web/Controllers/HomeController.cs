using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using SocialMedia.Model;
using SocialMedia.Web.Models;


namespace SocialMedia.Web.Controllers
{
    public class HomeController : Controller
    {
        SocialMediaDbContext _dbcontext;
        int UserId;
        IHttpContextAccessor _httpContextAccessor;


        private readonly IHostingEnvironment _environment;

        public HomeController(IHostingEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _environment = environment;
            _dbcontext = new SocialMediaDbContext();

            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            UserId = Int32.Parse(cookievalue);
        }

        [Authorize]
        public IActionResult Index()
        {
           try
            {
                var postlist = _dbcontext.Post.Include(s => s.Comments).ThenInclude(sa => sa.User).Include(s => s.User).ThenInclude(saa => saa.FromFriends)
               .Include(s => s.User).ThenInclude(saa => saa.ToFriends).Include(s => s.LikeDislikes)
               .Where(c => c.User.ToFriends.Where(k => k.FromUserId == UserId && k.Status == 1).Count() != 0
               || c.User.FromFriends.Where(k => k.ToUserId == UserId && k.Status == 1).Count() != 0 || c.User.Id == UserId)
               .OrderByDescending(c => c.Time).ToList();

                HomeIndexModel model = new HomeIndexModel()
                {
                    PostModel = postlist,
                    UserId = UserId,
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

        public InsertPostModel InsertPost(string text, IFormFile file)
        {
            try
            {
                string fileName = null;

                if (file != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    file.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Post obj = new Post()
                {
                    Text = text,
                    PhotoPath = fileName,
                    UserId = UserId,

                    Time = DateTime.Now

                };


                _dbcontext.Post.Add(obj);

                _dbcontext.SaveChanges();
                var user = _dbcontext.User.Single(c => c.Id == obj.UserId);
                InsertPostModel model = new InsertPostModel()
                {
                    Id = obj.Id,
                    NameSurname = user.Name + " " + user.Surname,
                    PPPath = user.PhotoPath,
                    Time = obj.Time,
                    Text = obj.Text,
                    PhotoPath = obj.PhotoPath,
                    LikeCount = _dbcontext.LikeDislike.Where(c => c.PostId == obj.Id && c.LikeOrDislike).Count(),
                    DislikeCount = _dbcontext.LikeDislike.Where(c => c.PostId == obj.Id && !c.LikeOrDislike).Count(),
                    CommentCount = obj.Comments.Count
                };


                return model;

            }
            catch (Exception e)
            {
                return null;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public InsertCommentModel InsertComment(int postId, string text)
        {
           try
            {
                Comment comment = new Comment()
                {
                    Text = text,
                    PostId = postId,
                    UserId = UserId,
                    Like = 0,
                    Dislike = 0,
                    Time = DateTime.Now

                };

                _dbcontext.Comment.Add(comment);
                _dbcontext.SaveChanges();
                var user = _dbcontext.User.Single(c => c.Id == comment.UserId);

                InsertCommentModel model = new InsertCommentModel()
                {
                    NameSurname = user.Name + " " + user.Surname,
                    PhotoPath = user.PhotoPath,
                    Text = comment.Text
                };

                return model;
            }
            catch(Exception e)
            {
                return null;
            }
            

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public LikeDislikeModel LikeDislike(int id, bool likeordislike)
        {
            try
            {
                var likedislike = _dbcontext.LikeDislike.SingleOrDefault(c => c.PostId == id && c.UserId == UserId);
                int status;

                if (likedislike == null)
                {
                    _dbcontext.LikeDislike.Add(new LikeDislike()
                    {
                        PostId = id,
                        UserId = UserId,
                        LikeOrDislike = likeordislike

                    });
                    status = 1;

                }

                else
                {
                    bool flag = likedislike.LikeOrDislike;
                    if (flag == likeordislike)
                    {
                        _dbcontext.LikeDislike.Remove(likedislike);
                        status = 0;
                    }
                    else
                    {
                        likedislike.LikeOrDislike = likeordislike;
                        status = 2;
                    }
                }


                _dbcontext.SaveChanges();

                LikeDislikeModel likedislikemodel = new LikeDislikeModel()
                {
                    LikeCount = _dbcontext.LikeDislike.Where(c => c.PostId == id && c.LikeOrDislike).Count(),
                    DislikeCount = _dbcontext.LikeDislike.Where(c => c.PostId == id && !c.LikeOrDislike).Count(),
                    Status = status
                };


                return likedislikemodel;
            }
            catch(Exception e)
            {
                return null;
            }

        }



    }
}
