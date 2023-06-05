using WeatherForecastApp.Models;
using WeatherForecastApp.Data.Repository.IRepository;
namespace WeatherForecastApp.Data.Repository;

public class WeatherRepository : Repository<Weather>, IWeatherRepository
{
    private WeatherDbContext _db;
    public WeatherRepository(WeatherDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Weather obj)
    {
        _db.Weathers?.Update(obj);
    }
}