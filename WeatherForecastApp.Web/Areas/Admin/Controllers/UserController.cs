using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherForecastApp.Data;
using WeatherForecastApp.Utility;

namespace WeatherForecastApp.Web.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class UserController : Controller
{
    private readonly WeatherDbContext _context;

    public UserController(WeatherDbContext context)
    {
        _context = context;
    }
    // GET: Admin/User
    public async Task<IActionResult> Index()
    {
        return View(await _context.Users.Take(100).ToListAsync());
    }
    
    /*public IActionResult Delete(string? email)
    {
        if (email == null)
            return NotFound();
        var weather = _context.Users.FirstOrDefault(u => u.Email == email);
        if (weather == null)
            return NotFound();

        return View(weather);
    }
    
    // POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(string? email)
    {
        var weather = _context.Users.FirstOrDefault(u => u.Email == email);

        if (weather == null)
            return NotFound();

        _context.Users.Remove(weather);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }*/
    // POST
    public IActionResult Delete(string email)
    {
        if (string.IsNullOrEmpty(email))
            return NotFound();

        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user == null)
            return NotFound();

        return View(user);
    }

// POST: Admin/User/Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user == null)
            return NotFound();

        _context.Users.Remove(user);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}