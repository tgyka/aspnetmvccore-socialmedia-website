using SocialMedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Web.Models
{
    public class SearchIndex
    {
        public List<User> Model { get; set; }

        public int UserId { get; set; }
    }
}
