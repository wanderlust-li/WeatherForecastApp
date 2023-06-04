using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastApp.Data;
using WeatherForecastApp.Models;
using WeatherForecastApp.Utility;

namespace WeatherForecastApp.Web.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class WeatherAdminController : Controller
{
    private readonly WeatherDbContext _context;

    public WeatherAdminController(WeatherDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        IEnumerable<Weather> weathers = _context.Weathers;

        return View(weathers);
    }
}