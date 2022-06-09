using SocialMedia.Application.Message.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Application.Message
{
    public interface IMessageService
    {
        Task<bool> AddMessage(Model.Message messageModel);
        Task<List<MessageDto>> GetMessages(int userId, int targetId);
    }
}