using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using something.Models;

namespace something.Controllers
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

        public IActionResult handbooks()
        {
            return View();
        }

        public IActionResult Grades()
        {
            return View();
        }

        public IActionResult gifted_grants()
        {
            return View();
        }

        public IActionResult zapros1()
        {
            return View();
        }
    }
}

               

