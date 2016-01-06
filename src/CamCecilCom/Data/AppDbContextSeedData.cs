using CamCecilCom.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;

namespace CamCecilCom.Data
{
    public class AppDbContextSeedData
    {
        private AppDbContext _context;
        private UserManager<User> _userManager;

        public AppDbContextSeedData(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void EnsureSeedData()
        {
            if (!_context.BlogPosts.Any())
            {
                // Create the fakeUser
                var fakeUser = new User()
                {
                    UserName = "Cambo"
                };

                // Add the fakeUser to the context
                _context.Users.Add(fakeUser);

                // Create the fake blog post
                var fakeBlogPost = new BlogPost()
                {
                    Id = Guid.NewGuid().ToString(),
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
