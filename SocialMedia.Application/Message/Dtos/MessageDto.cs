using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Application.Message.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }

    }
}
