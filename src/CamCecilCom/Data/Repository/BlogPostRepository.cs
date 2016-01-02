using CamCecilCom.Models;
using System.Collections.Generic;
using System.Linq;

namespace CamCecilCom.Data.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private AppDbContext _context;

        public BlogPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogPost> GetAll()
        {
            return _context.BlogPosts
                .OrderBy(p => p.Created)
                .ToList();
        }
    }
}
