using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Application.Comment;
using SocialMedia.Application.Friend;
using SocialMedia.Application.LikeDislike;
using SocialMedia.Application.Message;
using SocialMedia.Application.Post;
using SocialMedia.Application.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Application.DependencyInjection
{
    public class AddApplicationDependencies
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<ILikeDislikeService, LikeDislikeService>();
            services.AddTransient<IMessageService, MessageService>();
        }
    }
}
