using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.User
{
    public class UserService : IUserService
    {
        private readonly SocialMediaDbContext _dbContext;

        public UserService(SocialMediaDbContext socialMediaDbContext)
        {
            _dbContext = socialMediaDbContext;
        }


        public async Task<Model.User> GetUser(int userId)
        {
            try
            {
                var user = await _dbContext.User.SingleAsync(c => c.Id == userId);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("User is null");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<Model.User> GetUserWithFriendsByUserId(int userId)
        {
            try
            {
                var user = await _dbContext.User
                    .Include(s => s.ToFriends)
                    .Include(s => s.FromFriends)
                    .Include(s => s.Posts)
                        .ThenInclude(s => s.Comments)
                            .ThenInclude(s => s.User)
                    .SingleAsync(s => s.Id == userId);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("User is null");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Model.User> GetUserWithFriendsByUsername(string username)
        {
            try
            {
                var user = await _dbContext.User
                    .Include(s => s.ToFriends)
                    .Include(s => s.FromFriends)
                    .Include(s => s.Posts)
                        .ThenInclude(s => s.Comments)
                            .ThenInclude(s => s.User)
                    .SingleAsync(s => s.Username == username);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("User is null");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Model.User>> GetUsersWithMessages(int userId)
        {
            try
            {
                var userlistwithmessages = await _dbContext.User
                    .Include(s => s.ToMessages)
                    .Include(s => s.FromMessages)
                    .Where(c =>
                        c.ToMessages
                            .Where(s => s.FromUserId == userId).Count() != 0 ||
                        c.FromMessages
                            .Where(s => s.ToUserId == userId).Count() != 0)
                    .ToListAsync();

                if (userlistwithmessages != null)
                {
                    return userlistwithmessages;
                }
                else
                {
                    throw new Exception("Userlist is null");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<string> GetPhotoPath(int userId)
        {
            try
            {
                var user = await _dbContext.User.SingleAsync(c => c.Id == userId);

                if (user != null)
                {
                    return user.PhotoPath;
                }
                else
                {
                    throw new Exception("User is null");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<List<Model.User>> SearchUser(string searchText)
        {
            try
            {
                var users = await _dbContext.User
                    .Include(s => s.FromFriends)
                        .ThenInclude(s => s.FromUser)
                    .Include(s => s.ToFriends)
                        .ThenInclude(s => s.ToUser)
                    .Where(c =>
                        c.Name
                            .Contains(searchText) ||
                        c.Surname
                            .Contains(searchText) ||
                        c.Username
                            .Contains(searchText))
                    .ToListAsync();

                if (users != null)
                {
                    return users;
                }
                else
                {
                    throw new Exception("User is null");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }



        public async Task<int> GetUserIdByUserName(string userName)
        {
            try
            {
                var user = await _dbContext.User.SingleAsync(c => c.Username == userName);

                if (user != null)
                {
                    return user.Id;
                }
                else
                {
                    throw new Exception("User is null");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> LoginUser(string userName, string password)
        {
            try
            {
                var user = await _dbContext.User.SingleAsync(c => c.Username == userName && c.Password == password);

                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> UserHasExist(string userName)
        {
            try
            {
                var user = await _dbContext.User.SingleAsync(c => c.Username == userName);

                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> AddUser(Model.User userModel)
        {
            try
            {
                await _dbContext.User.AddAsync(userModel);


                await _dbContext.SaveChangesAsync();

                return true;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> UpdateUser(Model.User userModel)
        {
            try
            {
                var user = await _dbContext.User
                    .SingleAsync(c => c.Id == userModel.Id);

                if (user != null)
                {
                    user.Username = userModel.Username;
                    user.Name = userModel.Name;
                    user.Surname = userModel.Surname;
                    user.Email = userModel.Email;
                    user.Bio = userModel.Bio;
                    user.PhotoPath = userModel.PhotoPath;
                    user.Password = userModel.Password;
                }
                else
                {
                    throw new Exception("User model is null");
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
