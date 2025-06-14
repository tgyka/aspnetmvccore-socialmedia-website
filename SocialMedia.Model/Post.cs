using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialMedia.Model
{
    [Table("Post")]
    public class Post : BaseClass
    {

        public Post()
        {
            Comments = new HashSet<Comment>();
            LikeDislikes = new HashSet<LikeDislike>();
        }

        public string Text { get; set; }

        public int UserId { get; set; }

        public string PhotoPath { get; set; }

        public DateTime Time { get; set; }

        

        public virtual User User { get; set; }

        public virtual ICollection<LikeDislike> LikeDislikes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string GetTimeFormat(TimeSpan time)
        {
            

            if (time < new TimeSpan(0, 0, 1, 0, 0)) {
                return "just now";
            }
            else if(time < new TimeSpan(0, 1, 0, 0, 0))
            {
                return time.Minutes + " minutes";
            }
            else if(time < new TimeSpan(1,0,0,0,0))
            {
                return time.Hours + " hours";
            }
            else if(time < new TimeSpan(365,0,0,0,0))
            {
                return time.Days + " days";
            }
            else if(TimeSpan.FromDays(365) <= time )
            {
                return (time.Days / 365) + " years";
            }
            else { return null; }
        
        }

    }
}
