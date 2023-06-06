using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastApp.Data;
using WeatherForecastApp.Models;
using WeatherForecastApp.Utility;
using MoreLinq;
using MoreLinq.Extensions;
using WeatherForecastApp.Data.Repository.IRepository;

namespace WeatherForecastApp.Web.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class WeatherAdminController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public WeatherAdminController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    // GET
    public IActionResult Index()
    {
        IEnumerable<Weather> weathers = _unitOfWork.WeatherR.GetAll();

        return View(weathers);
    }

    public IActionResult Delete(int? id)
    {
        if (id == 0 || id == null)
            return NotFound();
        var weather = _unitOfWork.WeatherR.Get(u => u.Id == id);
        if (weather == null)
            return NotFound();

        return View(weather);
    }
    
    // POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int ?id)
    {
        var weather = _unitOfWork.WeatherR.Get(u => u.Id == id);

        if (weather == null)
            return NotFound();

        _unitOfWork.WeatherR.Remove(weather);
        _unitOfWork.Save();

        return RedirectToAction("Index");
    }
    public IActionResult CountHotDays()
    {
        var hotDaysCount = _unitOfWork.WeatherR.GetAll()
            .Where(w => w.City == "Kyiv" && w.Temperature > 20)
            .Select(w => w.DateTime.Date)
            .Distinct()
            .Count();

        ViewBag.HotDaysCount = hotDaysCount;

        return View();
    }
}