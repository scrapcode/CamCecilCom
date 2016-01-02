using System;
using Microsoft.AspNet.Mvc;

using CamCecilCom.Data.Repository;
using CamCecilCom.Models;

namespace CamCecilCom.Controllers
{
    [Route("api/[controller]")]
    public class BlogPostController : Controller
    {
        private IBlogPostRepository _repository;

        public BlogPostController(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_repository.GetAll());
        }
    }
}
