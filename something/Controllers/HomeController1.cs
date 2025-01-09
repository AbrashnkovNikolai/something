using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace something.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
