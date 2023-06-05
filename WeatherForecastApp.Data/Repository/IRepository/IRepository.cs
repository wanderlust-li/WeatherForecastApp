using System.Linq.Expressions;

namespace WeatherForecastApp.Data.Repository.IRepository;

public interface IRepository<T> where T: class
{
    IEnumerable<T> GetAll();
    void Remove(T entity);
    void Add(T entity);
    T Get(Expression<Func<T, bool>> filter);
}