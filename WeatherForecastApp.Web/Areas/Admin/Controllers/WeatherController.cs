using Microsoft.AspNetCore.Mvc;

namespace WeatherForecastApp.Web.Areas.Admin.Controllers;
[Area("Admin")]
public class WeatherController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}