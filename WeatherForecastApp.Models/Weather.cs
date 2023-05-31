using System.ComponentModel.DataAnnotations;

namespace WeatherForecastApp.Models;

public class Weather
{
    [Key]
    public int Id { get; set; }
    public string City { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; } // вологість
    public float WindSpeed { get; set; } // швидкість вітру
    public string WeatherDescription { get; set; } // опис погоди
    public DateTime DateTime { get; set; } = DateTime.Now;
}