using CamCecilCom.Models;
using System;

namespace CamCecil.Models
{
    public class BlogPost
    {
        public int      Id { get; set; }
        public string   Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public User     Author { get; set; }
        public string   MyProperty { get; set; }
    }
}
