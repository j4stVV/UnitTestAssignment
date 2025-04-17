using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;

namespace R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
