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

        public List<MessageModel> MessagesList { get; set; }

    }

    
    public class MessageModel
    {
        public int Id { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }

    }

}
