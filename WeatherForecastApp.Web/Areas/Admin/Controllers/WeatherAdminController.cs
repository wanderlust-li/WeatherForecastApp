using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastApp.Data;
using WeatherForecastApp.Models;
using WeatherForecastApp.Utility;
using MoreLinq;
using MoreLinq.Extensions;

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

    public IActionResult Delete(int? id)
    {
        if (id == 0 || id == null)
            return NotFound();
        var weather = _context.Weathers.FirstOrDefault(u => u.Id == id);
        if (weather == null)
            return NotFound();

        return View(weather);
    }
    
    // POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int ?id)
    {
        var weather = _context.Weathers.FirstOrDefault(u => u.Id == id);

        if (weather == null)
            return NotFound();

        _context.Weathers.Remove(weather);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    public IActionResult CountHotDays()
    {
        var hotDaysCount = _context.Weathers
            .Where(w => w.City == "Kyiv" && w.Temperature > 20)
            .Select(w => w.DateTime.Date)
            .Distinct()
            .Count();

        ViewBag.HotDaysCount = hotDaysCount;

        return View();
    }
}