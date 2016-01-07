using System;
using Microsoft.AspNet.Mvc;

using CamCecilCom.Data.Repository;
using CamCecilCom.Models;
using CamCecilCom.ViewModels;
using System.Linq;

namespace CamCecilCom.Controllers
{
    [Route("api/[controller]")]
    public class BlogPostController : Controller
    {
        private BlogPostRepository _repository;

        public BlogPostController(BlogPostRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_repository.GetAllWithChildren());
        }

        [HttpGet("{id}")]
        public JsonResult Get(string id)
        {
            return Json(_repository.GetById(id));
        }

        [HttpPost]
        public JsonResult Post([FromBody]BlogPostViewModel post)
        {
            if (ModelState.IsValid)
            {
                // Map to a BlogPost
                BlogPost blogPost = new BlogPost()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = post.Title,
                    Author = null,
                    Body = post.Body,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow
                };

                _repository.Add(blogPost);
                _repository.Save();

                return Json(blogPost);
            }

            return Json(new {
                errorCount = ModelState.ErrorCount,
                errors = ModelState.Values.SelectMany(e => e.Errors)
            });
        }
    }
}
