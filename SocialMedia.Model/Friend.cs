using SocialMedia.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialMedia.Model
{
    [Table("Friend")]
    public class Friend : BaseClass
    {
        public int ToUserId { get; set; }

        public int FromUserId { get; set; }

        public FriendStatus Status { get; set; }

        public virtual User ToUser { get; set; }

        public virtual User FromUser { get; set; }
    }
}
