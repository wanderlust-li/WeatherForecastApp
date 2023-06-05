namespace WeatherForecastApp.Data.Repository.IRepository;

public interface IRepository<T> where T: class
{
    IEnumerable<T> GetAll();
    void Remove(T entity);
}