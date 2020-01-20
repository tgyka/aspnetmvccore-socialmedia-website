using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialMedia.Model
{
    [Table("Message")]
    public class Message : BaseClass
    {
        public string Text { get; set; }

        public int ToUserId { get; set; }

        public int FromUserId { get; set; }

        public DateTime Time { get; set; }

        public virtual User ToUser { get; set; }

        public virtual User FromUser { get; set; }



    }
}
