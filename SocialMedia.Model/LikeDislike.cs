using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialMedia.Model
{
    [Table("LikeDislike")]
    public class LikeDislike : BaseClass
    {
        public int UserId { get; set; }

        public int PostId { get; set; }

        public bool LikeOrDislike { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
