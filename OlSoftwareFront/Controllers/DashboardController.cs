using Microsoft.AspNetCore.Mvc;

namespace OlSoftwareFront.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
