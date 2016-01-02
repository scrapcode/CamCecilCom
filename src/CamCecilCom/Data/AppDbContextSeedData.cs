using CamCecilCom.Models;
using System;
using System.Linq;

namespace CamCecilCom.Data
{
    public class AppDbContextSeedData
    {
        private AppDbContext _context;

        public AppDbContextSeedData(AppDbContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.BlogPosts.Any())
            {
                // Create the fakeUser
                var fakeUser = new User()
                {
                    Username = "cambo"
                };

                // Add the fakeUser to the context
                _context.Users.Add(fakeUser);

                // Create the fake blog post
                var fakeBlogPost = new BlogPost()
                {
                    Title = "Hello world!",
                    Created = DateTime.UtcNow,
                    Author = fakeUser,
                    Body = "Lorem Ipsum!",
                    Modified = DateTime.UtcNow
                };

                // Add the fake post to the context.
                _context.BlogPosts.Add(fakeBlogPost);

                // Save to the database
                _context.SaveChanges();
            }
        }
    }
}
