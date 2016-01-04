using CamCecilCom.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CamCecilCom.ViewModels
{
    public class BlogPostViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }
        public User Author { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
