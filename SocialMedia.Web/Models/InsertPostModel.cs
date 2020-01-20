using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Web.Models
{
    public class InsertPostModel
    {
        public int Id { get; set; }

        public string NameSurname  { get; set; }

        public string PPPath { get; set; }

        public DateTime Time { get; set; }

        public string Text { get; set; }

        public string PhotoPath { get; set; }

        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }

        public int CommentCount { get; set; }

    }
}
