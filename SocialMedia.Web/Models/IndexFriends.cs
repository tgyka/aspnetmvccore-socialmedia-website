using SocialMedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Web.Models
{
    public class IndexFriends
    {
        public List<Friend> PendingFriends { get; set; }

        public List<Friend> FriendsTo { get; set; }

        public List<Friend> FriendsFrom { get; set; }

    }
}
