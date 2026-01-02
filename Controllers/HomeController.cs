using Microsoft.AspNetCore.Mvc;

namespace SiteSafe4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
