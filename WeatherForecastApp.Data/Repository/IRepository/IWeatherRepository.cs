using WeatherForecastApp.Models;

namespace WeatherForecastApp.Data.Repository.IRepository;

public interface IWeatherRepository : IRepository<Weather>
{
    void Update(Weather obj);
}