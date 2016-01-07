using System;
using Microsoft.AspNet.Mvc;

using CamCecilCom.Data.Repository;

namespace CamCecilCom.Controllers
{
    public class AdminController : Controller
    {
        private AdminRepository _repository;
        
        public AdminController(AdminRepository repository)
        {
            _repository = repository;
        }
        
        // GET /Admin/
        public Index()
        {
            return View();
        }
    }
}