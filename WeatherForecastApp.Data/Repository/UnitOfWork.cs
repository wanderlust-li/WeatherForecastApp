using WeatherForecastApp.Data.Repository.IRepository;

namespace WeatherForecastApp.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly WeatherDbContext _db;
    public IWeatherRepository WeatherR { get; private set; }

    public UnitOfWork(WeatherDbContext db)
    {
        _db = db;
        WeatherR = new WeatherRepository(_db);
    }
    
    public void Save()
    {
        _db.SaveChanges();
    }
}