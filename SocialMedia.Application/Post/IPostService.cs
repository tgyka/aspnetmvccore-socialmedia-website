using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Application.Post
{
    public interface IPostService
    {
        Task<bool> AddPost(Model.Post post);
        Task<List<Model.Post>> GetPosts(int userId);
    }
}