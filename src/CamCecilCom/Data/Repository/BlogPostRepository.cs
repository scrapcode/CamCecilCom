using CamCecilCom.Models;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CamCecilCom.Data.Repository
{
    public class BlogPostRepository : IRepository<BlogPost, string>
    {
        private AppDbContext _context;

        public BlogPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogPost> GetAll()
        {
            return _context.BlogPosts
                .OrderByDescending(p => p.Created)
                .ToList();
        }

        public IEnumerable<BlogPost> GetAllWithChildren()
        {
            return _context.BlogPosts
                .Include(p => p.Author)
                .OrderByDescending(p => p.Created)
                .ToList();
        }

        public BlogPost GetById(string id)
        {
            return _context.BlogPosts
                .Where(p => p.Id == id)
                .Include(p => p.Author)
                .First();
        }

        public void Add(BlogPost post)
        {
            try
            {
                post.Id = Guid.NewGuid().ToString();
                _context.BlogPosts.Add(post);
            }
            catch(Exception e)
            {
                // Exception caught.
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
