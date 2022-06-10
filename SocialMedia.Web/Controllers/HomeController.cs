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
using SocialMedia.Application.Post;
using SocialMedia.Application.User;
using SocialMedia.Application.LikeDislike;
using SocialMedia.Application.Comment;
using SocialMedia.Helper.File;

namespace SocialMedia.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly int _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly ILikeDislikeService _likeDislikeService;
        private readonly ICommentService _commentService;
        private readonly IFileHelper _fileHelper;
        private readonly IHostingEnvironment _environment;

        public HomeController(IHostingEnvironment environment, 
            IHttpContextAccessor httpContextAccessor,
            IPostService postService,
            IUserService userService,
            ILikeDislikeService likeDislikeService,
            ICommentService commentService,
            IFileHelper fileHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _environment = environment;

            var cookievalue = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            _userId = Int32.Parse(cookievalue);

            _postService = postService;
            _userService = userService;
            _likeDislikeService = likeDislikeService;
            _commentService = commentService;
            _fileHelper = fileHelper;
        }


        public async Task<IActionResult> Index()
        {
            var postList = await _postService.GetPosts(_userId);

            var photoPath = await _userService.GetPhotoPath(_userId);


            HomeIndexModel model = new HomeIndexModel()
            {
                PostModel = postList,
                UserId = _userId,
                PPPath = photoPath
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<InsertPostModel> InsertPost(string text, IFormFile file)
        {

            string fileName = null;

            if (file != null)
            {
                fileName = await _fileHelper.UploadFile(_environment,file);
            }

            Post postModel = new Post
            {
                Text = text,
                PhotoPath = fileName,
                UserId = _userId,
                Time = DateTime.Now
            };

            await _postService.AddPost(postModel);


            var user = await _userService.GetUser(postModel.UserId);

            var likeCount = await _likeDislikeService.GetLikeCount(postModel.Id);

            var dislikeCount = await _likeDislikeService.GetDislikeCount(postModel.Id);

            InsertPostModel model = new InsertPostModel()
            {
                Id = postModel.Id,
                NameSurname = user.Name + " " + user.Surname,
                PPPath = user.PhotoPath,
                Time = postModel.Time,
                Text = postModel.Text,
                PhotoPath = postModel.PhotoPath,
                LikeCount = likeCount,
                DislikeCount = dislikeCount,
                CommentCount = postModel.Comments.Count
            };

            return model;

        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<InsertCommentModel> InsertComment(int postId, string text)
        {

            Comment commentModel = new Comment
            {
                Text = text,
                PostId = postId,
                UserId = _userId,
                Like = 0,
                Dislike = 0,
                Time = DateTime.Now
            };

            await _commentService.AddComment(commentModel);

            var user = await _userService.GetUser(commentModel.UserId);


            InsertCommentModel model = new InsertCommentModel()
            {
                NameSurname = user.Name + " " + user.Surname,
                PhotoPath = user.PhotoPath,
                Text = commentModel.Text
            };

            return model;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<LikeDislikeModel> LikeDislike(int postId, bool likeDislikeBoolValue)
        {

            var likeDislike = await _likeDislikeService.GetLikeDislike(_userId, postId);
            int status;

            if (likeDislike == null)
            {

                var likeDislikeModel = new LikeDislike
                {
                    PostId = postId,
                    UserId = _userId,
                    LikeOrDislike = likeDislikeBoolValue

                };

                await _likeDislikeService.AddLikeDislike(likeDislikeModel);

                status = 1;

            }
            else
            {
                if (likeDislike.LikeOrDislike == likeDislikeBoolValue)
                {
                    await _likeDislikeService.RemoveLikeDislike(likeDislike.Id);
                    status = 0;
                }
                else
                {
                    var likeDislikeModel = new LikeDislike
                    {
                        PostId = postId,
                        UserId = _userId,
                        LikeOrDislike = likeDislikeBoolValue

                    };
                        
                    await _likeDislikeService.UpdateLikeDislike(likeDislikeModel);
                    status = 2;
                }
            }

            var likeCount = await _likeDislikeService.GetLikeCount(postId);

            var dislikeCount = await _likeDislikeService.GetDislikeCount(postId);

            LikeDislikeModel likedislikemodel = new LikeDislikeModel()
            {
                LikeCount = likeCount,
                DislikeCount = dislikeCount,
                Status = status
            };

            return likedislikemodel;
        }


        



    }
}
