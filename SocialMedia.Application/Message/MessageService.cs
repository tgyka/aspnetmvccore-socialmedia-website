using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Message.Dtos;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Message
{
    public class MessageService : IMessageService
    {
        private readonly SocialMediaDbContext _dbContext;

        public MessageService(SocialMediaDbContext socialMediaDbContext)
        {
            _dbContext = socialMediaDbContext;
        }

        public async Task<List<MessageDto>> GetMessages(int userId, int targetId)
        {
            try
            {
                var messages = await _dbContext.Message
                    .Where(c => (c.FromUserId == targetId && c.ToUserId == userId) || (c.FromUserId == userId && c.ToUserId == targetId))
                    .Select(c => new MessageDto
                    {
                        Id = c.Id,
                        FromUserId = c.FromUserId,
                        ToUserId = c.ToUserId,
                        Text = c.Text,
                        Time = c.Time
                    })
                    .ToListAsync();

                return messages;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<bool> AddMessage(Model.Message messageModel)
        {
            try
            {
                await _dbContext.Message.AddAsync(messageModel);


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
