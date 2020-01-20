using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Web.Models
{
    public class LikeDislikeModel
    {
        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }

        public int Status { get; set; }
    }
}
