using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PhoenixTemplate.Models;
using PhoenixTemplate.Models.Accesos;

namespace PhoenixTemplate.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly AccesosContext _accesosContext;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env, IConfiguration configuration, AccesosContext accesosContext) : base(logger, env, configuration, accesosContext)
        {
            _logger = logger;
            _env = env;
            _configuration = configuration;
            _accesosContext = accesosContext;
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

        public IActionResult Error401()
        {
            return View();
        }

        public IActionResult Error403()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }

    }
}
