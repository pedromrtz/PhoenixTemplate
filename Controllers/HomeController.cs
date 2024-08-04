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

        [HttpGet("proxy-translate")]
        public async Task<IActionResult> ProxyTranslate(string q, string tl)
        {
            using var client = new HttpClient();
            var url = $"https://translate.google.com/translate_a/single?client=gtx&sl=auto&tl={tl}&dt=t&q={Uri.EscapeDataString(q)}";
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }


    }
}
