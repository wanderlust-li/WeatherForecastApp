using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastApp.Utility;

namespace WeatherForecastApp.Web.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class WeatherAdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}