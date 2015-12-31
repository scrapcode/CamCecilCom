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
    }
}
