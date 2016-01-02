using CamCecilCom.Models;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CamCecilCom.Data.Repository
{
    public class BlogPostRepository : IRepository<BlogPost, int>
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

        public IEnumerable<BlogPost> GetAllWithChildren()
        {
            return _context.BlogPosts
                .Include(p => p.Author)
                .OrderBy(p => p.Created)
                .ToList();
        }

        public BlogPost GetById(int id)
        {
            return _context.BlogPosts
                .Where(p => p.Id == id)
                .Include(p => p.Author)
                .First();
        }
    }
}
