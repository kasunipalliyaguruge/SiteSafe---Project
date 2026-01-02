using Microsoft.AspNetCore.Mvc;
using SiteSafe4.Data;

namespace SiteSafe4.Controllers
{
    public class LiveController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LiveController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            var cameras = _db.Cameras.ToList();
            return View(cameras);
        }
    }
}
