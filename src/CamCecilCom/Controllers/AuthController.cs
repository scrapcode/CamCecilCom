using Microsoft.AspNet.Mvc;
using System;

namespace CamCecilCom.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Main", "Index");
            }

            return View();
        }
    }
}
