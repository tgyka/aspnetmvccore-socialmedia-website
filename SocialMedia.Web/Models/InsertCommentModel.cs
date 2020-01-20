using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Web.Models
{
    public class InsertCommentModel
    {
        public string NameSurname { get; set; }

        public string PhotoPath { get; set; }

        public string Text { get; set; }
    }
}
