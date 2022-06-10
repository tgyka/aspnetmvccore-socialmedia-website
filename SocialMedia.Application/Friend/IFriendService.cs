using SocialMedia.Model;
using SocialMedia.Model.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Application.Friend
{
    public interface IFriendService
    {
        Task<bool> AddFriend(Model.Friend friend);
        Task<List<Model.Friend>> GetFromUserByFromUserId(int userId, FriendStatus status);
        Task<List<Model.Friend>> GetFromUserByToUserId(int userId, FriendStatus status);
        Task<List<Model.Friend>> GetToUserByFromUserId(int userId, FriendStatus status);
        Task<List<Model.Friend>> GetToUserByToUserId(int userId, FriendStatus status);
        Task<bool> RemoveFriend(int userId, int targetId);
        Task<bool> UpdateFriend(Model.Friend friend);
    }
}