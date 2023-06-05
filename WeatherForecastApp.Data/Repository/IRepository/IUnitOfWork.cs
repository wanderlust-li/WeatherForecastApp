namespace WeatherForecastApp.Data.Repository.IRepository;

public interface IUnitOfWork
{
    IWeatherRepository WeatherR { get; }
    void Save();
    Task SaveAsync();
}