using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using SocialMedia.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Post
{
    public class PostService : IPostService
    {
        private readonly SocialMediaDbContext _dbContext;

        public PostService(SocialMediaDbContext socialMediaDbContext)
        {
            _dbContext = socialMediaDbContext;
        }

        public async Task<List<Model.Post>> GetPosts(int userId)
        {
            try
            {
                var posts = await _dbContext.Post
                    .Include(s => s.Comments)
                        .ThenInclude(sa => sa.User)
                    .Include(s => s.User)
                        .ThenInclude(saa => saa.FromFriends)
                    .Include(s => s.User)
                        .ThenInclude(saa => saa.ToFriends)
                    .Include(s => s.LikeDislikes)
                    .Where(c => 
                        c.User.ToFriends
                            .Where(k => 
                                k.FromUserId == userId && 
                                k.Status == FriendStatus.Accepted)
                            .Count() != 0 || 
                        c.User.FromFriends.
                            Where(k => 
                                k.ToUserId == userId && 
                                k.Status == FriendStatus.Accepted)
                            .Count() != 0 || 
                        c.User.Id == userId)
                    .OrderByDescending(c => c.Time)
                    .ToListAsync();

                return posts;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> AddPost(Model.Post post)
        {
            try
            {
                if (post != null)
                {
                    await _dbContext.Post.AddAsync(post);

                    await _dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new Exception("Post is null");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
