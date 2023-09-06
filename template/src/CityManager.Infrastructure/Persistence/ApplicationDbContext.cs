using System.Reflection;
using Microsoft.EntityFrameworkCore;

using CityManager.Domain.Entities;

namespace CityManager.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<City> Cities { get; set; }
 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}