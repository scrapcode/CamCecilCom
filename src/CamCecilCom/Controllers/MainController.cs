using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace CamCecilCom.Controllers
{
    public class MainController : Controller
    {
        // GET /
        // GET /home/index/
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult SecureArea()
        {
            return View();
        }
    }
}
