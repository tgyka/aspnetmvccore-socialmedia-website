using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Text;
using SocialMedia.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Model.Enums;

namespace SocialMedia.Application.Friend
{
    public class FriendService : IFriendService
    {
        private readonly SocialMediaDbContext _dbContext;

        public FriendService(SocialMediaDbContext socialMediaDbContext)
        {
            _dbContext = socialMediaDbContext;
        }

        public async Task<List<Model.Friend>> GetFromUserByFromUserId(int userId, FriendStatus status)
        {
            try
            {
                var fromUsers = await _dbContext.Friend
                    .Include(c => c.FromUser)
                    .Where(c => c.FromUserId == userId && c.Status == status)
                    .ToListAsync();

                return fromUsers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Model.Friend>> GetFromUserByToUserId(int userId, FriendStatus status)
        {
            try
            {
                var fromUsers = await _dbContext.Friend
                    .Include(c => c.FromUser)
                    .Where(c => c.ToUserId == userId && c.Status == status)
                    .ToListAsync();

                return fromUsers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Model.Friend>> GetToUserByFromUserId(int userId, FriendStatus status)
        {
            try
            {
                var toUsers = await _dbContext.Friend
                    .Include(c => c.ToUser)
                    .Where(c => c.FromUserId == userId && c.Status == status)
                    .ToListAsync();

                return toUsers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Model.Friend>> GetToUserByToUserId(int userId, FriendStatus status)
        {
            try
            {
                var toUsers = await _dbContext.Friend
                    .Include(c => c.ToUser)
                    .Where(c => c.ToUserId == userId && c.Status == status)
                    .ToListAsync();

                return toUsers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<bool> AddFriend(Model.Friend friend)
        {
            try
            {
                if(friend != null)
                {
                    await _dbContext.AddAsync(friend);

                    await _dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new Exception("Friend is null");
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> UpdateFriend(Model.Friend friend)
        {
            try
            {
                var friendModel = await _dbContext.Friend
                    .SingleAsync(c => c.ToUserId == friend.ToUserId && c.FromUserId == friend.FromUserId && c.Status == friend.Status);

                if (friendModel != null)
                {
                    friendModel.Status = friend.Status;
                    friendModel.ToUserId = friend.ToUserId;
                    friendModel.FromUserId = friend.FromUserId;
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

        public async Task<bool> RemoveFriend(int userId, int targetId)
        {
            try
            {
                var friendModel = await _dbContext.Friend
                    .SingleAsync(c => (c.ToUserId == userId && c.FromUserId == targetId) || (c.ToUserId == targetId && c.FromUserId == userId));

                if (friendModel != null)
                {
                    _dbContext.Remove(friendModel);
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
