using CamCecilCom.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CamCecilCom.Data
{
    public class AppDbContextSeedData
    {
        private AppDbContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public AppDbContextSeedData(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task EnsureSeedData()
        {
            if(!await _roleManager.RoleExistsAsync("Admin"))
            {
                IdentityRole adminRole = new IdentityRole("Admin");
                await _roleManager.CreateAsync(adminRole);
            }

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

                // Add the fake user to the role "Admin"
                await _userManager.AddToRoleAsync(fakeUser, "Admin");

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
