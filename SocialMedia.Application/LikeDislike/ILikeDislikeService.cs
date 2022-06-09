using System.Threading.Tasks;

namespace SocialMedia.Application.LikeDislike
{
    public interface ILikeDislikeService
    {
        Task<bool> AddLikeDislike(Model.LikeDislike likedislikeModel);
        Task<int> GetDislikeCount(int postId);
        Task<int> GetLikeCount(int postId);
        Task<Model.LikeDislike> GetLikeDislike(int userId, int postId);
        Task<bool> RemoveLikeDislike(int id);
        Task<bool> UpdateLikeDislike(Model.LikeDislike likeDislike);
    }
}