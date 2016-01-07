

using CamCecilCom.Data.Repository;
using CamCecilCom.Models;
using CamCecilCom.ViewModels;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

namespace CamCecilCom.Controllers
{
    public class BlogController : Controller
    {
        private BlogPostRepository _repository;

        public BlogController(BlogPostRepository repository)
        {
            _repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<BlogPost> blogPosts = _repository.GetAllWithChildren();

            List<BlogPostViewModel> blogPostVMs = new List<BlogPostViewModel>();

            foreach(BlogPost post in blogPosts)
            {
                blogPostVMs.Add(new BlogPostViewModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Author = post.Author,
                    Body = post.Body,
                    Created = post.Created,
                    Modified = post.Modified
                });
            }

            return View(blogPostVMs);
        }
    }
}
