using CamCecilCom.Data.Repository;
using Microsoft.AspNet.Mvc;
using System;

namespace CamCecilCom.Controllers
{
    [Route("api/[controller]")]
    public class BlogPostController : Controller
    {
        private BlogPostRepository _context;

        BlogPostController(BlogPostRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_context.GetAll());
        }
    }
}
