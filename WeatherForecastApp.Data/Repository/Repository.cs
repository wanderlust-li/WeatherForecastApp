using Microsoft.EntityFrameworkCore;
using WeatherForecastApp.Data.Repository.IRepository;

namespace WeatherForecastApp.Data.Repository;

public class Repository<T> : IRepository<T> where T: class
{
    private WeatherDbContext _db;
    internal DbSet<T> DbSet;

    public Repository(WeatherDbContext db)
    {
        _db = db;
        this.DbSet = _db.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = DbSet;
        return query.ToList();
    }
    
    public void Remove(T entity)
    {
        DbSet.Remove(entity);
    }
}