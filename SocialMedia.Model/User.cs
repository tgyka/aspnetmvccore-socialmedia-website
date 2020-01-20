using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialMedia.Model
{
    [Table("User")]
   public class User : BaseClass
    {

        public User()
        {
            Comments = new HashSet<Comment>();

            ToFriends = new HashSet<Friend>();

            FromFriends = new HashSet<Friend>();

            ToMessages = new HashSet<Message>();

            FromMessages = new HashSet<Message>();

            Posts = new HashSet<Post>();

            LikeDislikes = new HashSet<LikeDislike>();


        }


        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Bio { get; set; }

        public string Location { get; set; }

        public string PhotoPath { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Friend> ToFriends { get; set; }

        public virtual ICollection<Friend> FromFriends { get; set; }

        public virtual ICollection<Message> ToMessages { get; set; }

        public virtual ICollection<Message> FromMessages { get; set; }

        public virtual ICollection<LikeDislike> LikeDislikes { get; set; }


        public virtual ICollection<Post> Posts { get; set; }




    }
}
