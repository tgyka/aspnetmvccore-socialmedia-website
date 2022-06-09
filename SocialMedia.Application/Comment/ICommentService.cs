using System.Threading.Tasks;

namespace SocialMedia.Application.Comment
{
    public interface ICommentService
    {
        Task<bool> AddComment(Model.Comment commentModel);
    }
}