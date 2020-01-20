using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialMedia.Model
{
  public  class BaseClass
    {
        [Key]
        public int Id { get; set; }
    }
}
