using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Application.User
{
    public interface IUserService
    {
        Task<bool> AddUser(Model.User userModel);
        Task<string> GetPhotoPath(int userId);
        Task<Model.User> GetUser(int userId);
        Task<int> GetUserIdByUserName(string userName);
        Task<List<Model.User>> GetUsersWithMessages(int userId);
        Task<Model.User> GetUserWithFriendsByUserId(int userId);
        Task<Model.User> GetUserWithFriendsByUsername(string username);
        Task<bool> LoginUser(string userName, string password);
        Task<List<Model.User>> SearchUser(string searchText);
        Task<bool> UpdateUser(Model.User userModel);
        Task<bool> UserHasExist(string userName);
    }
}