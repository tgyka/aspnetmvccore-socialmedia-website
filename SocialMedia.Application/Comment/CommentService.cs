using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Comment
{
    public class CommentService : ICommentService
    {
        private readonly SocialMediaDbContext _dbContext;

        public CommentService(SocialMediaDbContext socialMediaDbContext)
        {
            _dbContext = socialMediaDbContext;
        }

        public async Task<bool> AddComment(Model.Comment commentModel)
        {
            try
            {
                await _dbContext.Comment.AddAsync(commentModel);


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
