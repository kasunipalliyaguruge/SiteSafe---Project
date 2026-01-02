using Microsoft.AspNetCore.Mvc;
using SiteSafe4.Data;
using System.Linq;

namespace SiteSafe4.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DashboardController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            var model = new
            {
                WorkersCount = _db.Workers.Count(),
                CamerasCount = _db.Cameras.Count(),
                AlertsCount = _db.Alerts.Count()
            };
            return View(model);
        }
        public IActionResult LiveMonitoring()
        {
            var model = new
            {
                WorkersCount = 25,
                CamerasCount = 5,
                AlertsCount = 2,
                PPECompliance = 88, // % of workers wearing PPE
                FatigueLevel = 20   // % of fatigued workers
            };

            return View(model);
        }

        public IActionResult PPEDetection() => View();

        public IActionResult FatigueDetection() => View();

        public IActionResult Alerts() => View();

        public IActionResult Reports() => View();

        public IActionResult Settings() => View();
    }
}
