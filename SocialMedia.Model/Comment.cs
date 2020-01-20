using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialMedia.Model
{
    [Table("Comment")]
    public class Comment : BaseClass
    {
        public string Text { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }

        public DateTime Time { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
}
}
