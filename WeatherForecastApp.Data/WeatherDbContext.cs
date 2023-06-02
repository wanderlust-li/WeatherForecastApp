using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Data;

public class WeatherDbContext : IdentityDbContext<IdentityUser>
{
    public WeatherDbContext()
    {
    }

    public WeatherDbContext(DbContextOptions<WeatherDbContext> context) : base(context)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Weather;Trusted_Connection=True;");
    }
    
    public DbSet<Weather> Weathers { get; set; }
}