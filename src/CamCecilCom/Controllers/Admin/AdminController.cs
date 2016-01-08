using System;
using Microsoft.AspNet.Mvc;

using CamCecilCom.Data.Repository;
using CamCecilCom.Models;
using Microsoft.AspNet.Identity;

namespace CamCecilCom.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<User> _userManager;
        private BlogPostRepository _postRepository;


        public AdminController(UserManager<User> userManager, BlogPostRepository postRepository)
        {
            _userManager = userManager;
            _postRepository = postRepository;
        }
        
        // GET /Admin/
        public IActionResult Index()
        {
            return View();
        }
    }
}