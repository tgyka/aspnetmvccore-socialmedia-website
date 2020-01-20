using SocialMedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Web.Models
{
    public class HomeIndexModel
    {
        public List<Post> PostModel { get; set; }

        public int UserId { get; set; }

        public string PPPath { get; set; }
    }
}
