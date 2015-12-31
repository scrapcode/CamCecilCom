using System;
using System.ComponentModel.DataAnnotations;

namespace CamCecilCom.Models
{
    public class BlogPost
    {
        [Key]
        public int      Id { get; set; }
        public string   Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public User     Author { get; set; }
        public string   Body { get; set; }
    }
}
