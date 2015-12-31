using CamCecilCom.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamCecilCom.Data.Repository
{
    public class BlogPostRepository : IRepository<BlogPost>
    {
        private AppDbContext _context;

        BlogPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogPost> GetAll()
        {
            return _context.BlogPosts.ToList();
        }
    }
}
