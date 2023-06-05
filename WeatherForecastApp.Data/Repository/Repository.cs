using System.Linq.Expressions;
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
    
    public void Add(T entity)
    {
        DbSet.Add(entity);
    }
    
    public T Get(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = DbSet;
        query = query.Where(filter);
        return query.FirstOrDefault();
    }
}