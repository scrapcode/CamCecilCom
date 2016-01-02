using System;
using Microsoft.AspNet.Mvc;

using CamCecilCom.Data.Repository;
using CamCecilCom.Models;

namespace CamCecilCom.Controllers
{
    [Route("api/[controller]")]
    public class BlogPostController : Controller
    {
        private IRepository<BlogPost, int> _repository;

        public BlogPostController(IRepository<BlogPost, int> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_repository.GetAllWithChildren());
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_repository.GetById(id));
        }
    }
}
