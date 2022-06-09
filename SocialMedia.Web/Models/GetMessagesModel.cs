using SocialMedia.Application.Message.Dtos;
using SocialMedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Web.Models
{
    public class GetMessagesModel
    {
        public User User { get; set; }

        public List<MessageDto> MessagesList { get; set; }

    }

}
