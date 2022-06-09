using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.LikeDislike
{
    public class LikeDislikeService : ILikeDislikeService
    {
        private readonly SocialMediaDbContext _dbContext;

        public LikeDislikeService(SocialMediaDbContext socialMediaDbContext)
        {
            _dbContext = socialMediaDbContext;
        }

        public async Task<Model.LikeDislike> GetLikeDislike(int userId, int postId)
        {
            try
            {
                var likedislike = await _dbContext.LikeDislike.SingleAsync(c => c.PostId == postId && c.UserId == userId);

                if (likedislike != null)
                {
                    return likedislike;
                }
                else
                {
                    throw new Exception("Likedislike is null");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<int> GetLikeCount(int postId)
        {
            try
            {
                var count = await _dbContext.LikeDislike.Where(c => c.PostId == postId && c.LikeOrDislike).CountAsync();

                return count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> GetDislikeCount(int postId)
        {
            try
            {
                var count = await _dbContext.LikeDislike.Where(c => c.PostId == postId && !c.LikeOrDislike).CountAsync();

                return count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> AddLikeDislike(Model.LikeDislike likedislikeModel)
        {
            try
            {
                await _dbContext.LikeDislike.AddAsync(likedislikeModel);


                await _dbContext.SaveChangesAsync();

                return true;

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<bool> UpdateLikeDislike(Model.LikeDislike likeDislike)
        {
            try
            {
                var likeDislikeModel = await _dbContext.LikeDislike
                    .SingleAsync(c => c.Id == likeDislike.Id);

                if (likeDislikeModel != null)
                {
                    likeDislikeModel.LikeOrDislike = likeDislike.LikeOrDislike;
                }
                else
                {
                    throw new Exception("LikeDislike model is null");
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> RemoveLikeDislike(int id)
        {
            try
            {
                var likeDislikeModel = await _dbContext.LikeDislike.SingleAsync(c => c.Id == id);

                if (likeDislikeModel != null)
                {
                    _dbContext.Remove(likeDislikeModel);
                }
                else
                {
                    throw new Exception("Friend model is null");
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
