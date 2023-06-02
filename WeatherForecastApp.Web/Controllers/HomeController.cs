using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherForecastApp.Data;
using WeatherForecastApp.Models;
using WeatherForecastApp.Web.Models;

namespace WeatherForecastApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherDbContext _context;

        public HomeController(ILogger<HomeController> logger, WeatherDbContext context)
        {
            _context = context;
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