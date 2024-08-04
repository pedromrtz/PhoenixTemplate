using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PhoenixTemplate.Models;

namespace PhoenixTemplate.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ForgotPass()
        {
            return View();
        }

        public IActionResult Home()
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
