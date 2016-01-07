using CamCecilCom.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task EnsureSeedData()
        {
            if (!_context.BlogPosts.Any())
            {
                // Create the fake user
                var fakeUser = new User()
                {
                    UserName = "cam",
                    Email = "ctcecil@gmail.com"
                };

                // Add the fake user to the database
                await _userManager.CreateAsync(fakeUser, "P@ssw0rd!1");

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
