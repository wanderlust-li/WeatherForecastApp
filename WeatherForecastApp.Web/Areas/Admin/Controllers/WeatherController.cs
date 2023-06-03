using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WeatherForecastApp.Data;
using WeatherForecastApp.Models;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace WeatherForecastApp.Web.Areas.Admin.Controllers;
[Area("Admin")]
public class WeatherController : Controller
{
    private readonly WeatherDbContext _context;

    public WeatherController(WeatherDbContext context)
    {
        _context = context;
    }
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(string city)
    {
        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=9171b06eb5989b5061b6e96161ced43a");

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(responseStream);
            var json = await reader.ReadToEndAsync();
            var weatherResponse = JObject.Parse(json);

            var weather = new Weather
            {
                City = weatherResponse["name"].ToString(),
                Temperature = float.Parse(weatherResponse["main"]["temp"].ToString()) - 273.15F, // Conversion from Kelvin to Celsius
                Humidity = float.Parse(weatherResponse["main"]["humidity"].ToString()),
                WindSpeed = float.Parse(weatherResponse["wind"]["speed"].ToString()),
                WeatherDescription = weatherResponse["weather"][0]["description"].ToString(),
                DateTime = DateTime.Now
            };

            _context.Weathers.Add(weather);
            await _context.SaveChangesAsync();

            return View(weather);
        }

        return NotFound();
    }
}